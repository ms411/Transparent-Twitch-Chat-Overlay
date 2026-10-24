using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransparentTwitchChatWPF.Utils;

public static class Growl
{
    public static event Action<string> GrowlMessageRequested;

    public static void Info(string message)
    {
        GrowlMessageRequested?.Invoke("[INFO] " + message);
    }

    public static void Warning(string message)
    {
        GrowlMessageRequested?.Invoke("[WARNING] " + message);
    }

    public static void Error(string message)
    {
        GrowlMessageRequested?.Invoke("[ERROR] " + message);
    }

    // Routine connection status messages (connect, reconnect, transient errors).
    // These are only shown in chat when the user has enabled
    // "Show Twitch connection status messages in chat" in General settings.
    private static bool ShowConnectionStatus =>
        App.Settings?.GeneralSettings?.ShowConnectionStatusInChat ?? false;

    public static void ConnectionInfo(string message)
    {
        if (ShowConnectionStatus) Info(message);
    }

    public static void ConnectionError(string message)
    {
        if (ShowConnectionStatus) Error(message);
    }
}
