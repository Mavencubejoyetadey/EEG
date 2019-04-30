# EEG
EEG software

Form1.cs
----------
createBasicMontage() : craete "B-Map" montage with predefined channels

backgroundProc(): Runs the thread and call ReadBuffer() method to read data from serial port.

loadMontage(): load channels into the left panel and according to that their value will be added to the list into the component. 

LoadData() from customcontrol2 will be called from ReadBuffer() and show it into a chart

CustomControl2.cs
-----------------

FFT ,IFFT,High pass and low pass filter, notch applied to the data in loadData().

On a timerEvent OnTimedEvent() chart will be invoked and add data from <graphdata> buffer. 

loadTimeline(): called to create timeline in sec under the chart (our sample rate is 400 data per second)
