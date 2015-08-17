Imports System.Threading

Module Module_Semaphore
    Public Sub iniSemaphore()
        _poolFile_thread = New Semaphore(0, 1)
        _poolFile_thread.Release(1)
        _poolSeqNumber = New Semaphore(0, 1)
        _poolSeqNumber.Release(1)
        '車機封包串接問題處理 Jason 20150817
        'S-----------------------------------------------------------------------------------------------
        _poolCarPackOption = New Semaphore(0, 1)
        _poolCarPackOption.Release(1)
        'E-----------------------------------------------------------------------------------------------
    End Sub


End Module