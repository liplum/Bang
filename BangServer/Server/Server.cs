using Bang.Core;
using Bang.Services;
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

    private void ServerRegisterHanlder(IServiceRegistry registry)
    {
        registry.RegisterSingleton<ILoggerService, CmdServerLogger>();
    }
}
