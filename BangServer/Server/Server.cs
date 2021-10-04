using Bang.Core;
using Bang.Networks;
using Bang.Services;
using BangServer.Networks;
using BangServer.Services;
using BangGame = Bang.Core.BangGame;

namespace BangServer.Server;
public class Server
{
    public BangGame? Game;

    public void Initialize()
    {
        Game = BangGame.MainGame;
        Game.ServiceRegisterEvent += ServerRegisterHanlder;
        Game.Initialize();
    }

    private Network Network => new();

    private void ServerRegisterHanlder(IServiceRegistry registry)
    {
        registry.RegisterSingleton<ILoggerService, CmdServerLogger>();
        registry.RegisterInstance<INetwork>(Network);
    }

    public void WaitForConnection()
    {

    }
}
