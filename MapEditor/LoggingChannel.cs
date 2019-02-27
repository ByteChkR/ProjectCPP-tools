using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    public enum LoggingChannel
    {
        GENERAL = 1,
        LOG = 2,
        WARNING = 4,
        ERROR = 8,
        ADL = 16,
        MAIN_EDITOR = 32,
        WINDOWS_FORM = 64,
        LANESTEP_EDITOR = 128,
        PARTCREATOR_EDITOR = 256,
        NEWMAPDIALOG_EDITOR = 512,
        MGE_ENGINE_CONSOLE_OUT = 1024,
        MGE_ENGINE_CONSOLE_ERR_OUT = 2048
    }
}
