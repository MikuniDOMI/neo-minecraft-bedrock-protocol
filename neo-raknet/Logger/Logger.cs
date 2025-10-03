namespace neo_protocol.Logger;

public class Logger
{
    private readonly TextWriter _writer = Console.Out;
    private bool savefile;

    public Logger(bool savefile = false)
    {
        this.savefile = savefile;
    }

    private string GetTime()
    {
        return DateTime.Now.TimeOfDay.ToString();
    }

    public void Info<T>(T str)
    {
        _writer.WriteLine(GetTime() + " " + Header.INFO + str);
    }

    public void error<T>(T str)
    {
        _writer.WriteLine(GetTime() + " " + Header.ERROR + str);
    }

    public void warn<T>(T str)
    {
        _writer.WriteLine(GetTime() + " " + Header.WARN + str);
    }

    public void debug<T>(T str)
    {
#if DEBUG
        _writer.WriteLine(GetTime() + " " + Header.DEBUG + str);
#endif
    }

    private enum LogLevel
    {
        info,
        warn,
        error,
        debug
    }

    private struct Header
    {
        public static readonly string INFO = "\x1b[1m[\x1b[36mINFO\x1b[0m\x1b[1m]\x1b[0m ";
        public static readonly string WARN = "\x1b[1m[\x1b[33mWARN\x1b[0m\x1b[1m]\x1b[0m ";
        public static readonly string ERROR = "\x1b[1m[\x1b[31mERROR\x1b[0m\x1b[1m]\x1b[0m ";
        public static readonly string DEBUG = "\x1b[1m[\x1b[33mDEBUG\x1b[0m\x1b[1m]\x1b[0m ";
    }
}