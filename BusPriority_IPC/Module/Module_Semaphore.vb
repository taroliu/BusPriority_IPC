Imports System.Threading

Module Module_Semaphore
    Public Sub iniSemaphore()
        _poolFile_thread = New Semaphore(0, 1)
        _poolFile_thread.Release(1)


    End Sub
End Module