$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition
cd $scriptPath

$proto_dir = "../proto"
$dest = "coincoolproto/"
# $tools_path = "$ENV:UserProfile/.nuget/packages/grpc.tools/1.20.0/tools/windows_x86"
# $proto_tools_path = "$ENV:UserProfile/.nuget/packages/google.protobuf.tools/3.7.0/tools"
$tools_path = "$scriptPath/grpctools"
$proto_tools_path = "$scriptPath/grpctools"

New-Item -ItemType Directory -Force -Path $dest

echo $ENV:UserProfile

& "$tools_path/protoc.exe" --proto_path=$proto_tools_path --proto_path=$proto_dir @(Get-ChildItem -Path $proto_dir -Filter *.proto -Recurse | Resolve-Path -Relative) --csharp_out "$dest" --grpc_out "$dest" --plugin=protoc-gen-grpc="$tools_path/grpc_csharp_plugin.exe"
if ($LastExitCode -ne 0)
{
	exit 1
}