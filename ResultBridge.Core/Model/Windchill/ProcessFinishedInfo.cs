namespace ResultBridge.Core.Model.Windchill;

internal class ProcessFinishedInfo
{
    public ProcessFinishedInfo(int exitCode, string stdOut, string stdErr)
    {
        ExitCode = exitCode;
        StdOut = stdOut;
        StdErr = stdErr;
    }

    public int ExitCode { get; set; }
    public string StdOut { get; set; }
    public string StdErr { get; set; }
}