
using CoinCool.Models;
using Newtonsoft.Json;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinCool.Services
{
    class CryptoService : IDisposable
    {
        public event EventHandler<SocketCrypto> SocketCryptoData;
        System.Timers.Timer _timer = new System.Timers.Timer(15000);
        ClientWebSocket ws;
        private string key;

        public CryptoService(string nameKey)
        {
            _timer.Elapsed += _timer_Elapsed;
            key = "market.trade." + nameKey;
        }

        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (ws.State == WebSocketState.Open)
            {
                await SendData("2");
            }
        }

        private async Task SendData(String str)
        {
            var encoded2 = Encoding.UTF8.GetBytes(str);
            var buffer2 = new ArraySegment<Byte>(encoded2, 0, encoded2.Length);
            await ws.SendAsync(buffer2, WebSocketMessageType.Text, true, CancellationToken.None);
        }


        public async void StartLoadingData()
        {
            ws = new ClientWebSocket();
            await ws.ConnectAsync(new Uri("wss://api.bitkub.com/websocket-api/"+key), CancellationToken.None);

            _timer.Start();

            ArraySegment<Byte> readbuffer = new ArraySegment<byte>(new Byte[8192]);
            while (ws.State == WebSocketState.Open)
            {
                try
                {
                    var result = await ws.ReceiveAsync(readbuffer, CancellationToken.None);
                    var str = Encoding.Default.GetString(readbuffer.Array, readbuffer.Offset, result.Count);
                    SocketCrypto updateValue = JsonConvert.DeserializeObject<SocketCrypto>(str);
                    if (updateValue != null)
                    {
                        SocketCryptoData?.Invoke(this, updateValue);
                    }
                }
                catch (TaskCanceledException)
                {
                    System.Diagnostics.Debug.Write("WebSocket Stopped");
                }
            }
        }

        public async void StopLoadingData()
        {
            try
            {
                if (ws.State != WebSocketState.Closed)
                    await ws.CloseAsync(WebSocketCloseStatus.Empty, String.Empty, CancellationToken.None);
            }
            finally
            {
                ws.Dispose();
                _timer.Stop();
            }
        }

        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }

            if (ws != null)
            {
                ws.Dispose();
                ws = null;
            }
        }

    }
}
