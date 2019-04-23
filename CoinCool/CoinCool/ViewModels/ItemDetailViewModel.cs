using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoinCool.Models;
using Newtonsoft.Json;

namespace CoinCool.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public event EventHandler<SocketCrypto> SocketCryptoData;
        System.Timers.Timer _timer = new System.Timers.Timer(5000);
        ClientWebSocket ws;
        private SocketCrypto _socketCrypto;
        public SocketCrypto SocketCrypto {
            get => _socketCrypto;
            set
            {
                _socketCrypto = value;
                RaisePropertyChanged(nameof(SocketCrypto));
            }
        }
        public ItemDetailViewModel(CryptoInfo item)
        {
            Title = item?.name;
            SocketCrypto = new SocketCrypto
            {
                stream = item.name,
                id = item.id,
                last = item.last,
                lowestAsk = item.lowestAsk,
                highestBid = item.highestBid,
                percentChange = item.percentChange,
                baseVolume = item.baseVolume,
                quoteVolume = item.quoteVolume,
                isFrozen = item.isFrozen,
                high24hr = item.high24hr,
                low24hr = item.low24hr
            };
            StartLoadingData("market.ticker." + item.key.ToLower());
        }

        public async void StartLoadingData(string key)
        {
            ws = new ClientWebSocket();
            await ws.ConnectAsync(new Uri("wss://api.bitkub.com/websocket-api/" + key), CancellationToken.None);

            _timer.Start();

            ArraySegment<Byte> readbuffer = new ArraySegment<byte>(new Byte[8192]);
            while (ws.State == WebSocketState.Open)
            {
                Console.WriteLine("\r\n XXXXXXXXXXXXXXXXXXX WebSocketState of " + key + " is " + ws.State);
                try
                {
                    var result = await ws.ReceiveAsync(readbuffer, CancellationToken.None);
                    var str = Encoding.Default.GetString(readbuffer.Array, readbuffer.Offset, result.Count);
                    SocketCrypto updateValue = JsonConvert.DeserializeObject<SocketCrypto>(str);
                    if (updateValue != null)
                    {
                        SocketCrypto = updateValue;
                        SocketCryptoData?.Invoke(this, updateValue);
                    }
                    else
                    {
                        Console.WriteLine("XXXXXXXXXXXXXXXXXXX : Empty");
                    }
                }
                catch (TaskCanceledException)
                {
                    System.Diagnostics.Debug.Write("XXXXXXXXXXXXXXXXXXX WebSocket Stopped");
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
