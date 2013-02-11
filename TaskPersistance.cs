using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

using WinTasks = Microsoft.Win32.TaskScheduler;

namespace RealTemp4RTSS
{
    public class TaskPersistance
    {
        public static bool PersistTask(bool startAtLogon, bool startForAllUsers)
        {
            WinTasks.TaskService ts = new WinTasks.TaskService();
            try
            {
                WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();
                bool isElevated = (new WindowsPrincipal(currentIdentity).IsInRole(WindowsBuiltInRole.Administrator));
                WinTasks.Task task = ts.FindTask(Application.ProductName, false);

                if (startAtLogon)
                {
                    if (startForAllUsers && !isElevated)
                    {
                        return PersistTaskElevated(startAtLogon, startForAllUsers);
                    }
                    else
                    {
                        WinTasks.LogonTrigger trigger = (WinTasks.LogonTrigger)WinTasks.LogonTrigger.CreateTrigger(WinTasks.TaskTriggerType.Logon);
                        trigger.Enabled = true;
                        trigger.StartBoundary = DateTime.Today;
                        if (startForAllUsers)
                            trigger.UserId = null;
                        else
                            trigger.UserId = currentIdentity.Name;

                        WinTasks.ExecAction action = (WinTasks.ExecAction)WinTasks.ExecAction.CreateAction(WinTasks.TaskActionType.Execute);
                        action.Path = Application.ExecutablePath;
                        action.WorkingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                        if (task == null)
                        {
                            task = ts.AddTask(Application.ProductName, trigger, action, currentIdentity.Name);
                        }
                        else
                        {
                            task.Definition.Triggers.Clear();
                            task.Definition.Triggers.Add(trigger);
                            task.Definition.Actions.Clear();
                            task.Definition.Actions.Add(action);
                            task.RegisterChanges();
                        }
                    }
                }
                else if (task != null)
                {
                    ts.GetFolder("\\").DeleteTask(task.Name);
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                ts.Dispose();
            }
            return true;
        }

        private static bool PersistTaskElevated(bool startAtLogon, bool startForAllUsers)
        {
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.FileName = Application.ExecutablePath;
            psi.Arguments = "task " + (startAtLogon ? "save" : "delete") + " " + (startForAllUsers ? "all" : "current");
            psi.WorkingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            psi.UseShellExecute = true;
            psi.Verb = "runas";
            var process = System.Diagnostics.Process.Start(psi);
            process.WaitForExit();
            return (process.ExitCode == 0);
        }
    }
}
