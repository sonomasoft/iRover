Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data



Imports NationalInstruments.NI4882
Imports NationalInstruments.VisaNS
Imports System.IO






Public Class MainForm
    Dim HP34970A As Device
    Dim HP34401A As Device
    Dim TEKTDS2001C As Device
    Dim mbSession As UsbSession
    Dim HVTP11 As Double
    Dim DVM1_5M As Double
    Dim test1val As Double
    Dim test2val As Double
    Dim test3val As Double
    Dim test4val As Double
    Dim test5val As Double
    Dim test6val As Double
    Dim test7val As Double
    Dim test8val As Double
    Dim test9val As Double
    Dim test10val As Double














    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' change off color to black and set all LED's to off
        Led1.OffColor = Color.Black
        Led2.OffColor = Color.Black
        Led3.OffColor = Color.Black
        Led4.OffColor = Color.Black
        Led5.OffColor = Color.Black
        Led6.OffColor = Color.Black
        Led7.OffColor = Color.Black
        Led8.OffColor = Color.Black
        Led9.OffColor = Color.Black
        Led10.OffColor = Color.Black


        Led1.Value = False
        Led2.Value = False
        Led3.Value = False
        Led4.Value = False
        Led5.Value = False
        Led6.Value = False
        Led7.Value = False
        Led8.Value = False
        Led9.Value = False
        Led10.Value = False

        ' CLEAR OLD MEASUREMENTS
        Label4.Text = "0 V"
        Label5.Text = "0 V"
        Label7.Text = "0 mA"
        Label9.Text = "0 uS"
        Label11.Text = "0 V"
        Label13.Text = "0 uA"
        Label15.Text = "0 mS"
        Label17.Text = "0 uS"
        Label21.Text = "0 uS"
        Label23.Text = "0 V"

        'prompt for serial number
        Dim serial As String


        serial = InputBox("Enter Serial number", "iRover", "0")





        Call Test1()
        Call Test2()
        Call Test3()
        Call Test4()
        Call Test5()
        Call Test6()
        Call Test7()
        Call test8()
        Call test9()
        ' Call Test10()


        ' save data to file here.
        ' write to file

        ' get current time and date
        Dim time1 As Date = DateTime.Now

        Dim datenow As String = time1.ToString("MM/dd/yy")

        Dim tmpdate() As String

        tmpdate = Split(datenow, "/")
        ' build file name

        Dim filename As String = "testdata.txt"

        Dim timenow As String = time1.ToString("HH:mm")
        ' build output line
        Dim outstring As String

        outstring = datenow & "," & timenow & "," & serial & "," & Str(test1val) & "," & Str(test2val) & "," & Str(test3val) & "," & Str(test4val) & "," & Str(test5val) & "," & Str(test6val) & "," & Str(test7val) & "," & Str(test8val) & "," & Str(test9val) & "," & Str(test10val)


        ' open file and append
        Using w As StreamWriter = File.AppendText(filename)
            w.WriteLine(outstring)

            w.Flush()

            w.Close()


        End Using

        'open as append


        ' date and time stamp


        ' get data from globals



        ' append to file


        ' close file



    End Sub

    Private Sub Test1()

        ' this test will be done with a seies voltage devider resistor to get the voltage down 
        ' to below 300V.  Care will be needed to make sure the voltage never exceeds 300V even
        ' when the relay switch is open.



        ' Dim HP34970A As Device
        Dim response As String

        ' Let's start by turning the off color to Yellow to indicate the first test is running
        Led1.OffColor = Color.Yellow

        ' update screen
        Me.Refresh()


        ' connect and read voltage from 34401A

        TextBox1.Text = "Connecting to HP34401AA at Address 6" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf


        ' use dio to set up kent's fixture.

        HP34970A = New Device(0, 9, 0)
        Try





            HP34970A.Write(ReplaceCommonEscapeSequences("*idn?\n"))


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        ' read a response and place it on the text screen
        Try

            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            TextBox1.Text = TextBox1.Text & "Response =" & response & vbCrLf


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            response = "NOCONNECT"
        End Try

        If (InStr(response, "HP34970") = 0) Then
            TextBox1.Text = TextBox1.Text & "Connected to HP34970A" & vbCrLf
        Else
            TextBox1.Text = TextBox1.Text & "Connection Error" & vbCrLf

            ' exit the test.
            MessageBox.Show(" Connection Error.  Please Check Your Setup.")
        End If


        ' set up switch for measurement
        TextBox1.Text = TextBox1.Text & "Setting up switch for DC voltage measurement" & vbCrLf
        HP34970A.Write(ReplaceCommonEscapeSequences("*RST\n"))  ' ISSUE FACTORY RESET OF INSTRUMENT
        HP34970A.Write(ReplaceCommonEscapeSequences("SOURCE:DIGITAL:DATA:BYTE 191, (@201)\n"))  ' TURN ON POWER TO DUT // light load to allow regulation

        MessageBox.Show(" Place DUT in Fixture.")

        HP34970A.Write(ReplaceCommonEscapeSequences("SOURCE:DIGITAL:DATA:BYTE 188, (@201)\n"))  ' put under load



        HP34401A = New Device(0, 22, 0)   ' was 6

        Try





            HP34401A.Write(ReplaceCommonEscapeSequences("*idn?\n"))


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        ' read a response and place it on the text screen
        Try

            response = InsertCommonEscapeSequences(HP34401A.ReadString())

            TextBox1.Text = TextBox1.Text & "Response =" & response & vbCrLf


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            response = "NOCONNECT"
        End Try

        If (InStr(response, "34401A") <> 0) Then
            TextBox1.Text = TextBox1.Text & "Connected to HP34401A" & vbCrLf
        Else
            TextBox1.Text = TextBox1.Text & "Connection Error" & vbCrLf

            ' exit the test.
            MessageBox.Show(" Connection Error.  Please Check Your Setup.")
        End If


        ' measure and display
        HP34401A.Write(ReplaceCommonEscapeSequences("CONF:VOLT:DC 1000\n"))
        HP34401A.Write(ReplaceCommonEscapeSequences("TRIG:SOUR IMM\n"))
        HP34401A.Write(ReplaceCommonEscapeSequences("MEAS:VOLT:DC?\n"))

        response = InsertCommonEscapeSequences(HP34401A.ReadString())


        ' format the string for display
        Dim highvoltage As Double
        highvoltage = Val(response)
        HVTP11 = highvoltage
        test1val = highvoltage



        Label4.Text = Str(highvoltage) & " V"



        ' validate measurement

        If (highvoltage > 480) And (highvoltage < 510) Then
            ' pass
            Led1.Value = True

        Else
            ' fail
            Led1.OffColor = Color.Red
        End If



        '---------------------------------------------


        Me.Refresh()
        Delay(1000)


    End Sub

    Private Sub Test2()

        'VDVM1_5M = DVM1 reading = VHV_5M / 52.5 ± 2 %. 
        '(Note: this primarily checks the test circuit. Failure of this specification most 
        'likely indicates a problem with leakage current around test resistor R2, such as 
        'through flux residue or moisture.)



        'Dim HP34970A As Device
        Dim response As String

        ' Let's start by turning the off color to Yellow to indicate the first test is running
        Led2.OffColor = Color.Yellow
        ' update screen
        Me.Refresh()
        ' place some test in the text box indicating our status
        TextBox1.Text = "Connecting to HP34970A at Address 9" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf


        HP34970A = New Device(0, 9, 0)
        Try





            HP34970A.Write(ReplaceCommonEscapeSequences("*idn?\n"))


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        ' read a response and place it on the text screen
        Try

            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            TextBox1.Text = TextBox1.Text & "Response =" & response & vbCrLf


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            response = "NOCONNECT"
        End Try

        If (InStr(response, "HP34970") = 0) Then
            TextBox1.Text = TextBox1.Text & "Connected to HP34970A" & vbCrLf
        Else
            TextBox1.Text = TextBox1.Text & "Connection Error" & vbCrLf

            ' exit the test.
            MessageBox.Show(" Connection Error.  Please Check Your Setup.")
        End If


        ' set up switch for measurement
        TextBox1.Text = TextBox1.Text & "Setting up switch for DC voltage measurement" & vbCrLf
        '       HP34970A.Write(ReplaceCommonEscapeSequences("*RST\n"))  ' ISSUE FACTORY RESET OF INSTRUMENT
        HP34970A.Write(ReplaceCommonEscapeSequences("CONF:VOLT:DC (@101)\n"))  ' select DC voltage measurement
        HP34970A.Write(ReplaceCommonEscapeSequences("ROUT:CHAN:DELAY 0.1\n"))  ' DELAY IN SEC BETWEEN SWICH CLOSURE AND MEASUREMENT
        HP34970A.Write(ReplaceCommonEscapeSequences("TRIG:COUNT 10\n")) ' NUMBER OF READINGS TO AVE

        ' DISPLAY SOMETHING
        HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT 'HV TP12'\n"))
        Delay(500)
        ' SCAN THE DATA
        HP34970A.Write(ReplaceCommonEscapeSequences("INIT\n"))

        ' GET THE 10 READINGS FROM MEMORY
        ' GET THE NUMBER OF POINTS SCANNED




        Dim points As Integer

        Do
            HP34970A.Write(ReplaceCommonEscapeSequences("DATA:POINTS?\n"))
            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            points = Val(response)
        Loop Until points >= 1



        ' get the measurements from instrument memory one at a time and make average
        Dim i As Integer
        Dim total As Double
        total = 0
        For i = 1 To points

            HP34970A.Write(ReplaceCommonEscapeSequences("DATA:REMOVE? 1\n"))
            response = InsertCommonEscapeSequences(HP34970A.ReadString())
            total = total + Val(response)
        Next

        Dim ave As Double
        DVM1_5M = total
        ave = total * 52.5

        test2val = ave


        Label5.Text = Str(ave) & " V"

        ' check result against spec

        If (ave > (HVTP11 - (HVTP11 * 0.035)) And (ave < (HVTP11 + (HVTP11 * 0.035)))) Then
            'PASS
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' PASS'\n"))
            Led2.Value = True

        Else
            'FAIL
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' FAIL'\n"))
            Led2.OffColor = Color.Red
        End If

        ' DISPLAY RESULT ON FRONT PANEL
        Dim displaystr As String

        displaystr = "DISP:TEXT '" & Label5.Text & "'\n"


        HP34970A.Write(ReplaceCommonEscapeSequences(displaystr))
        ' hold for 2 seconds
        Delay(2000)




        ' update screen
        Me.Refresh()
        Delay(1000)



    End Sub

    Private Sub Test3()

        ' SUPPLY CURRENT FULL LOAD



        'Dim HP34970A As Device
        Dim response As String

        ' Let's start by turning the off color to Yellow to indicate the first test is running
        Led3.OffColor = Color.Yellow
        ' update screen
        Me.Refresh()
        ' place some test in the text box indicating our status
        TextBox1.Text = "Connecting to HP34970A at Address 9" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf


        HP34970A = New Device(0, 9, 0)
        Try





            HP34970A.Write(ReplaceCommonEscapeSequences("*idn?\n"))


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        ' read a response and place it on the text screen
        Try

            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            TextBox1.Text = TextBox1.Text & "Response =" & response & vbCrLf


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            response = "NOCONNECT"
        End Try

        If (InStr(response, "HP34970") = 0) Then
            TextBox1.Text = TextBox1.Text & "Connected to HP34970A" & vbCrLf
        Else
            TextBox1.Text = TextBox1.Text & "Connection Error" & vbCrLf

            ' exit the test.
            MessageBox.Show(" Connection Error.  Please Check Your Setup.")
        End If


        ' set up switch for measurement
        TextBox1.Text = TextBox1.Text & "Setting up switch for DC current measurement" & vbCrLf
        'HP34970A.Write(ReplaceCommonEscapeSequences("*RST\n"))  ' ISSUE FACTORY RESET OF INSTRUMENT
        HP34970A.Write(ReplaceCommonEscapeSequences("CONF:VOLT:DC (@102)\n"))   ' select DC voltage measurement
        HP34970A.Write(ReplaceCommonEscapeSequences("ROUT:CHAN:DELAY 0.1\n"))  ' DELAY IN SEC BETWEEN SWICH CLOSURE AND MEASUREMENT
        HP34970A.Write(ReplaceCommonEscapeSequences("TRIG:COUNT 10\n")) ' NUMBER OF READINGS TO AVE

        ' DISPLAY SOMETHING
        HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT 'CURRENT MEAS'\n"))
        Delay(500)
        ' SCAN THE DATA
        HP34970A.Write(ReplaceCommonEscapeSequences("INIT\n"))

        ' GET THE 10 READINGS FROM MEMORY
        ' GET THE NUMBER OF POINTS SCANNED




        Dim points As Integer

        Do
            HP34970A.Write(ReplaceCommonEscapeSequences("DATA:POINTS?\n"))
            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            points = Val(response)
        Loop Until points >= 1



        ' get the measurements from instrument memory one at a time and make average
        Dim i As Integer
        Dim total As Double
        total = 0
        For i = 1 To points

            HP34970A.Write(ReplaceCommonEscapeSequences("DATA:REMOVE? 1\n"))
            response = InsertCommonEscapeSequences(HP34970A.ReadString())
            total = total + Val(response)
        Next

        Dim ave As Double
        ave = ((total / 20) * 1000)   '(E2/20)-0.00936

        test3val = ave


        Label7.Text = Str(ave) & " mA"

        ' check result against spec
        ' DISPLAY RESULT ON FRONT PANEL
        Dim displaystr As String

        displaystr = "DISP:TEXT '" & Label7.Text & "'\n"


        HP34970A.Write(ReplaceCommonEscapeSequences(displaystr))
        ' hold for 2 seconds
        Delay(2000)

        ' check result against spec

        'assume pass for test
        If (ave > 20) And (ave < 30) Then
            'pass
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' PASS'\n"))
            Led3.Value = True
        Else
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' FAIL'\n"))
            Led3.OffColor = Color.Red
        End If


        ' update screen
        Me.Refresh()
        Delay(1000)




    End Sub
    Private Sub Test4()
        ' for this test we need to hook up to the scope and get a pulse width

        'Dim HP34970A As Device
        Dim response As String

        ' Let's start by turning the off color to Yellow to indicate the first test is running
        Led4.OffColor = Color.Yellow
        ' update screen
        Me.Refresh()
        ' place some test in the text box indicating our status
        TextBox1.Text = "Connecting to TEKTDS2001C at Address 10" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf

        ' open session with Tek scope



        'USB0::0x0699::0x03A0::C012871::INSTR

        'TEKTDS2001C = New Device(0, 10, 0)
        ' Dim mbSession As UsbSession

        Try
            mbSession = CType(ResourceManager.GetLocalManager().Open("USB0::0x0699::0x03A0::C012871::INSTR"), MessageBasedSession)

        Catch exp As InvalidCastException
            MessageBox.Show("Resource selected must be a message-based session")
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try






        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("*idn?\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try


        Try
            Dim responseString As String = mbSession.ReadString()
            response = InsertCommonEscapeSequences(responseString)
            TextBox1.Text = TextBox1.Text & response

        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try

        Me.Refresh()
        ' select channel 1
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("SELECT:CH2 OFF;:SELECT:CH1 ON\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        ' set up for horz, vert and trigger

        'VERTICAL
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("CH1:COUPLING DC;:CH1:SCALE 1.0E0;:CH1:POSITION -3\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        'HORZ

        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("HORIZONTAL:MAIN:SCALE 5.0E-6\n")  ' 5uS /DIV
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        'trigger
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("TRIGGER:MAIN:EDGE:SOURCE CH1;:TRIGGER:MAIN:LEVEL 1.4\n")  ' 5uS /DIV
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try


        'SET UP MEASUREMENT FOR POSITION 1
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("MEASUREMENT:MEAS1:SOURCE CH1;:MEASUREMENT:MEAS1:TYPE NWIDTH\n")  ' 5uS /DIV
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try


        'QUERRY THE MEASUREMENT
        ' wait a sec to allow measurement to update
        Delay(1000)
        MessageBox.Show("Place scope probe on TP4")

        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("MEASUREMENT:MEAS1:VALUE?\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        response = ""


        Try
            Dim responseString As String = mbSession.ReadString()
            response = InsertCommonEscapeSequences(responseString)
            TextBox1.Text = TextBox1.Text & response

        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try


        ' DISPLAY RESULT
        Dim negitivepulsewidth As Double

        negitivepulsewidth = (Val(response) * 1000000.0)

        test4val = negitivepulsewidth


        Label9.Text = Str(negitivepulsewidth) & " uS"


        ' validate result


        If ((negitivepulsewidth > 13) And (negitivepulsewidth < 21)) Then
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' PASS'\n"))
            Led4.Value = True

        Else
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' FAIL'\n"))
            Led4.OffColor = Color.Red
        End If


        ' grab the screen and show in new window




    End Sub

    Private Sub Test5()

        ' load regulation

        ' light load regulation  RL1 closed RL2 open


        ' Dim HP34970A As Device
        Dim response As String

        ' Let's start by turning the off color to Yellow to indicate the first test is running
        Led5.OffColor = Color.Yellow

        ' update screen
        Me.Refresh()

        ' place some test in the text box indicating our status
        TextBox1.Text = "Connecting to HP34970A at Address 9" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf


        HP34970A = New Device(0, 9, 0)
        Try





            HP34970A.Write(ReplaceCommonEscapeSequences("*idn?\n"))


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        ' read a response and place it on the text screen
        Try

            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            TextBox1.Text = TextBox1.Text & "Response =" & response & vbCrLf


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            response = "NOCONNECT"
        End Try

        If (InStr(response, "HP34970") = 0) Then
            TextBox1.Text = TextBox1.Text & "Connected to HP34970A" & vbCrLf
        Else
            TextBox1.Text = TextBox1.Text & "Connection Error" & vbCrLf

            ' exit the test.
            MessageBox.Show(" Connection Error.  Please Check Your Setup.")
        End If
        HP34970A.Write(ReplaceCommonEscapeSequences("SOURCE:DIGITAL:DATA:BYTE 190, (@201)\n"))  ' turn RL2 off


        ' set up switch for measurement
        TextBox1.Text = TextBox1.Text & "Setting up switch for DC voltage measurement" & vbCrLf
        ' HP34970A.Write(ReplaceCommonEscapeSequences("*RST\n"))  ' ISSUE FACTORY RESET OF INSTRUMENT
        HP34970A.Write(ReplaceCommonEscapeSequences("CONF:VOLT:DC (@101)\n"))  ' select DC voltage measurement
        HP34970A.Write(ReplaceCommonEscapeSequences("ROUT:CHAN:DELAY 0.1\n"))  ' DELAY IN SEC BETWEEN SWICH CLOSURE AND MEASUREMENT
        HP34970A.Write(ReplaceCommonEscapeSequences("TRIG:COUNT 10\n")) ' NUMBER OF READINGS TO AVE
        ' DISPLAY SOMETHING
        HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT 'HV TP11 LL'\n"))
        Delay(500)
        ' SCAN THE DATA
        HP34970A.Write(ReplaceCommonEscapeSequences("INIT\n"))

        ' GET THE 10 READINGS FROM MEMORY
        ' GET THE NUMBER OF POINTS SCANNED




        Dim points As Integer

        Do
            HP34970A.Write(ReplaceCommonEscapeSequences("DATA:POINTS?\n"))
            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            points = Val(response)
        Loop Until points >= 1



        ' get the measurements from instrument memory one at a time and make average
        Dim i As Integer
        Dim total As Double
        total = 0
        For i = 1 To points

            HP34970A.Write(ReplaceCommonEscapeSequences("DATA:REMOVE? 1\n"))
            response = InsertCommonEscapeSequences(HP34970A.ReadString())
            total = total + Val(response)
        Next

        Dim ave As Double
        ave = total

        test5val = total


        Label11.Text = Str(ave) & " V"

        ' DISPLAY RESULT ON FRONT PANEL
        Dim displaystr As String

        displaystr = "DISP:TEXT '" & Label11.Text & "'\n"


        HP34970A.Write(ReplaceCommonEscapeSequences(displaystr))
        ' hold for 2 seconds
        Delay(2000)

        ' check result against spec
        ' MUST BE WITH IN 2% OF DVM1_5m
        If ((ave > (ave - (DVM1_5M * 0.02))) And (ave < (ave + (DVM1_5M * 0.02)))) Then
            'pass
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' PASS'\n"))
            Led5.Value = True
        Else
            'fail
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' FAIL'\n"))
            Led5.OffColor = Color.Red

        End If

        ' update screen
        Me.Refresh()
        Delay(1000)


    End Sub




    Private Sub Test6()

        ' light load current

        ' light load regulation  RL1 and RL2 open


        ' Dim HP34970A As Device
        Dim response As String

        ' Let's start by turning the off color to Yellow to indicate the first test is running
        Led6.OffColor = Color.Yellow

        ' update screen
        Me.Refresh()

        ' place some test in the text box indicating our status
        TextBox1.Text = "Connecting to HP34970A at Address 9" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf


        HP34970A = New Device(0, 9, 0)
        Try





            HP34970A.Write(ReplaceCommonEscapeSequences("*idn?\n"))


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        ' read a response and place it on the text screen
        Try

            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            TextBox1.Text = TextBox1.Text & "Response =" & response & vbCrLf


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            response = "NOCONNECT"
        End Try

        If (InStr(response, "HP34970") = 0) Then
            TextBox1.Text = TextBox1.Text & "Connected to HP34970A" & vbCrLf
        Else
            TextBox1.Text = TextBox1.Text & "Connection Error" & vbCrLf

            ' exit the test.
            MessageBox.Show(" Connection Error.  Please Check Your Setup.")
        End If
        HP34970A.Write(ReplaceCommonEscapeSequences("SOURCE:DIGITAL:DATA:BYTE 191, (@201)\n"))  ' turn RL2 and RL1 off


        ' set up switch for measurement
        TextBox1.Text = TextBox1.Text & "Setting up switch for DC voltage measurement" & vbCrLf
        ' HP34970A.Write(ReplaceCommonEscapeSequences("*RST\n"))  ' ISSUE FACTORY RESET OF INSTRUMENT
        HP34970A.Write(ReplaceCommonEscapeSequences("CONF:VOLT:DC (@102)\n"))  ' select DC voltage measurement
        HP34970A.Write(ReplaceCommonEscapeSequences("ROUT:CHAN:DELAY 0.1\n"))  ' DELAY IN SEC BETWEEN SWICH CLOSURE AND MEASUREMENT
        HP34970A.Write(ReplaceCommonEscapeSequences("TRIG:COUNT 10\n")) ' NUMBER OF READINGS TO AVE
        ' DISPLAY SOMETHING
        HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT 'HV TP11 LL'\n"))
        Delay(500)
        ' SCAN THE DATA
        HP34970A.Write(ReplaceCommonEscapeSequences("INIT\n"))

        ' GET THE 10 READINGS FROM MEMORY
        ' GET THE NUMBER OF POINTS SCANNED




        Dim points As Integer

        Do
            HP34970A.Write(ReplaceCommonEscapeSequences("DATA:POINTS?\n"))
            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            points = Val(response)
        Loop Until points >= 1



        ' get the measurements from instrument memory one at a time and make average
        Dim i As Integer
        Dim total As Double
        total = 0
        For i = 1 To points

            HP34970A.Write(ReplaceCommonEscapeSequences("DATA:REMOVE? 1\n"))
            response = InsertCommonEscapeSequences(HP34970A.ReadString())
            total = total + Val(response)
        Next

        Dim ave As Double
        ave = ((total / 20) * 1000000.0) - 9.36

        test6val = ave

        Label13.Text = Str(ave) & " uA"

        ' DISPLAY RESULT ON FRONT PANEL
        Dim displaystr As String

        displaystr = "DISP:TEXT '" & Label11.Text & "'\n"


        HP34970A.Write(ReplaceCommonEscapeSequences(displaystr))
        ' hold for 2 seconds
        Delay(2000)

        ' check result against spec
        ' MUST BE WITH IN 2% OF DVM1_5m
        If (ave > 150) And (ave < 270) Then
            'pass
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' PASS'\n"))
            Led6.Value = True
        Else
            'fail
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' FAIL'\n"))
            Led6.OffColor = Color.Red

        End If

        ' update screen
        Me.Refresh()
        Delay(1000)


    End Sub

    Private Sub Test7()
        ' watchdog measurement TP5

        'Dim HP34970A As Device
        Dim response As String

        ' Let's start by turning the off color to Yellow to indicate the first test is running
        Led7.OffColor = Color.Yellow
        ' update screen
        Me.Refresh()

        ' set up switches for test

        ' place some test in the text box indicating our status
        TextBox1.Text = "Connecting to HP34970A at Address 9" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf


        HP34970A = New Device(0, 9, 0)
        Try





            HP34970A.Write(ReplaceCommonEscapeSequences("*idn?\n"))


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        ' read a response and place it on the text screen
        Try

            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            TextBox1.Text = TextBox1.Text & "Response =" & response & vbCrLf


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            response = "NOCONNECT"
        End Try

        If (InStr(response, "HP34970") = 0) Then
            TextBox1.Text = TextBox1.Text & "Connected to HP34970A" & vbCrLf
        Else
            TextBox1.Text = TextBox1.Text & "Connection Error" & vbCrLf

            ' exit the test.
            MessageBox.Show(" Connection Error.  Please Check Your Setup.")
        End If
        HP34970A.Write(ReplaceCommonEscapeSequences("SOURCE:DIGITAL:DATA:BYTE 187, (@201)\n"))  ' turn RL2 and RL1 off tp3 shorted to ground








        ' place some test in the text box indicating our status
        TextBox1.Text = "Connecting to TEKTDS2001C at Address 10" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf

        ' open session with Tek scope



        'USB0::0x0699::0x03A0::C012871::INSTR

        'TEKTDS2001C = New Device(0, 10, 0)
        ' Dim mbSession As UsbSession

        Try
            mbSession = CType(ResourceManager.GetLocalManager().Open("USB0::0x0699::0x03A0::C012871::INSTR"), MessageBasedSession)

        Catch exp As InvalidCastException
            MessageBox.Show("Resource selected must be a message-based session")
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try






        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("*idn?\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try


        Try
            Dim responseString As String = mbSession.ReadString()
            response = InsertCommonEscapeSequences(responseString)
            TextBox1.Text = TextBox1.Text & response

        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try

        Me.Refresh()

        ' set up for horz, vert and trigger




        'VERTICAL
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("CH1:COUPLING DC;:CH1:SCALE 1.0E0;:CH1:POSITION 0\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        'HORZ

        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("HORIZONTAL:MAIN:SCALE 50E-3\n")  ' 50Ms /DIV
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        'trigger
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("TRIGGER:MAIN:EDGE:SOURCE CH1;:TRIGGER:MAIN:LEVEL 1.4\n")  ' 5uS /DIV
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try


        'SET UP MEASUREMENT FOR POSITION 1
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("MEASUREMENT:MEAS1:TYPE PWIDTH\n")  ' 5uS /DIV
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try


        'QUERRY THE MEASUREMENT
        ' wait a sec to allow measurement to update
        Delay(1000)
        MessageBox.Show("Press OK to continue")

        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("MEASUREMENT:MEAS1:VALUE?\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        response = ""


        Try
            Dim responseString As String = mbSession.ReadString()
            response = InsertCommonEscapeSequences(responseString)
            TextBox1.Text = TextBox1.Text & response

        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try


        ' DISPLAY RESULT
        Dim positivepulsewidth As Double

        positivepulsewidth = (Val(response) * 1000.0)

        test7val = positivepulsewidth


        Label15.Text = Str(positivepulsewidth) & " mS"


        ' validate result


        If ((positivepulsewidth > 185) And (positivepulsewidth < 285)) Then
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' PASS'\n"))
            Led7.Value = True

        Else
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' FAIL'\n"))
            Led7.OffColor = Color.Red
        End If


        ' grab the screen and show in new window




    End Sub

    Private Sub test8()
        ' watchdog measurement TP5

        'Dim HP34970A As Device
        Dim response As String

        ' Let's start by turning the off color to Yellow to indicate the first test is running
        Led8.OffColor = Color.Yellow
        ' update screen
        Me.Refresh()

        ' set up switches for test

        ' place some test in the text box indicating our status
        TextBox1.Text = "Connecting to HP34970A at Address 9" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf


        HP34970A = New Device(0, 9, 0)
        Try





            HP34970A.Write(ReplaceCommonEscapeSequences("*idn?\n"))


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        ' read a response and place it on the text screen
        Try

            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            TextBox1.Text = TextBox1.Text & "Response =" & response & vbCrLf


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            response = "NOCONNECT"
        End Try

        If (InStr(response, "HP34970") = 0) Then
            TextBox1.Text = TextBox1.Text & "Connected to HP34970A" & vbCrLf
        Else
            TextBox1.Text = TextBox1.Text & "Connection Error" & vbCrLf

            ' exit the test.
            MessageBox.Show(" Connection Error.  Please Check Your Setup.")
        End If
        HP34970A.Write(ReplaceCommonEscapeSequences("SOURCE:DIGITAL:DATA:BYTE 255, (@201)\n"))  ' RL1 and RL2 Open.  Enable GEN1








        ' place some test in the text box indicating our status
        TextBox1.Text = "Connecting to TEKTDS2001C at Address 10" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf

        ' open session with Tek scope



        'USB0::0x0699::0x03A0::C012871::INSTR

        'TEKTDS2001C = New Device(0, 10, 0)
        ' Dim mbSession As UsbSession

        Try
            mbSession = CType(ResourceManager.GetLocalManager().Open("USB0::0x0699::0x03A0::C012871::INSTR"), MessageBasedSession)

        Catch exp As InvalidCastException
            MessageBox.Show("Resource selected must be a message-based session")
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try






        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("*idn?\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try


        Try
            Dim responseString As String = mbSession.ReadString()
            response = InsertCommonEscapeSequences(responseString)
            TextBox1.Text = TextBox1.Text & response

        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try

        Me.Refresh()

        ' select channel 2
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("SELECT:CH1 OFF;:SELECT:CH2 ON\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        ' set up for horz, vert and trigger




        'VERTICAL
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("CH2:COUPLING DC;:CH2:SCALE 1.0E0;:CH2:POSITION 0\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        'HORZ

        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("HORIZONTAL:MAIN:SCALE 25E-6\n")  ' 25uS /DIV
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        'trigger
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("TRIGGER:MAIN:EDGE:SOURCE CH2;:TRIGGER:MAIN:LEVEL 1.4\n")  ' 5uS /DIV
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try


        'SET UP MEASUREMENT FOR POSITION 1
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("MEASUREMENT:MEAS1:SOURCE CH2;:MEASUREMENT:MEAS1:TYPE NWIDTH\n")  ' 5uS /DIV
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try


        'QUERRY THE MEASUREMENT
        ' wait a sec to allow measurement to update
        Delay(1000)
        MessageBox.Show("Press OK to continue")

        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("MEASUREMENT:MEAS1:VALUE?\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        response = ""


        Try
            Dim responseString As String = mbSession.ReadString()
            response = InsertCommonEscapeSequences(responseString)
            TextBox1.Text = TextBox1.Text & response

        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try


        ' DISPLAY RESULT
        Dim negitivepulsewidth As Double

        negitivepulsewidth = (Val(response) * 1000000.0)

        test8val = negitivepulsewidth


        Label17.Text = Str(negitivepulsewidth) & " uS"


        ' validate result


        If ((negitivepulsewidth > 19) And (negitivepulsewidth < 31)) Then
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' PASS'\n"))
            Led8.Value = True

        Else
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' FAIL'\n"))
            Led8.OffColor = Color.Red
        End If


        ' grab the screen and show in new window




    End Sub

    Private Sub test9()
        ' watchdog measurement TP5

        'Dim HP34970A As Device
        Dim response As String

        ' Let's start by turning the off color to Yellow to indicate the first test is running
        Led9.OffColor = Color.Yellow
        ' update screen
        Me.Refresh()

        ' set up switches for test

        ' place some test in the text box indicating our status
        TextBox1.Text = "Connecting to HP34970A at Address 9" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf


        HP34970A = New Device(0, 9, 0)
        Try





            HP34970A.Write(ReplaceCommonEscapeSequences("*idn?\n"))


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        ' read a response and place it on the text screen
        Try

            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            TextBox1.Text = TextBox1.Text & "Response =" & response & vbCrLf


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            response = "NOCONNECT"
        End Try

        If (InStr(response, "HP34970") = 0) Then
            TextBox1.Text = TextBox1.Text & "Connected to HP34970A" & vbCrLf
        Else
            TextBox1.Text = TextBox1.Text & "Connection Error" & vbCrLf

            ' exit the test.
            MessageBox.Show(" Connection Error.  Please Check Your Setup.")
        End If
        HP34970A.Write(ReplaceCommonEscapeSequences("SOURCE:DIGITAL:DATA:BYTE 223, (@201)\n"))  ' RL1 and RL2 Open.  Enable GEN1 , SWITCH CHAN 2








        ' place some test in the text box indicating our status
        TextBox1.Text = "Connecting to TEKTDS2001C at Address 10" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf

        ' open session with Tek scope



        'USB0::0x0699::0x03A0::C012871::INSTR

        'TEKTDS2001C = New Device(0, 10, 0)
        ' Dim mbSession As UsbSession

        Try
            mbSession = CType(ResourceManager.GetLocalManager().Open("USB0::0x0699::0x03A0::C012871::INSTR"), MessageBasedSession)

        Catch exp As InvalidCastException
            MessageBox.Show("Resource selected must be a message-based session")
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try






        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("*idn?\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try


        Try
            Dim responseString As String = mbSession.ReadString()
            response = InsertCommonEscapeSequences(responseString)
            TextBox1.Text = TextBox1.Text & response

        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try

        Me.Refresh()

        ' select channel 2
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("SELECT:CH1 OFF;:SELECT:CH2 ON\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        ' set up for horz, vert and trigger




        'VERTICAL
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("CH2:COUPLING DC;:CH2:SCALE 1.0E0;:CH2:POSITION -2\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        'HORZ

        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("HORIZONTAL:MAIN:SCALE 250E-6\n")  ' 250uS /DIV
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        'trigger
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("TRIGGER:MAIN:EDGE:SOURCE CH2;:TRIGGER:MAIN:LEVEL 1.4\n")  ' 5uS /DIV
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try


        'SET UP MEASUREMENT FOR POSITION 1
        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("MEASUREMENT:MEAS1:SOURCE CH2;:MEASUREMENT:MEAS1:TYPE PWIDTH\n")  ' 5uS /DIV
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try


        'QUERRY THE MEASUREMENT
        ' wait a sec to allow measurement to update
        Delay(1000)
        MessageBox.Show("Press OK to continue")

        Try
            Dim textToWrite As String = ReplaceCommonEscapeSequences("MEASUREMENT:MEAS1:VALUE?\n")
            mbSession.Write(textToWrite)
        Catch exp As Exception
            MessageBox.Show(exp.Message)
        End Try

        response = ""


        Try
            Dim responseString As String = mbSession.ReadString()
            response = InsertCommonEscapeSequences(responseString)
            TextBox1.Text = TextBox1.Text & response

        Catch exp As Exception
            MessageBox.Show(exp.Message)
        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try


        ' DISPLAY RESULT
        Dim positivepulsewidth As Double

        positivepulsewidth = (Val(response) * 1000000.0)

        test9val = positivepulsewidth


        Label21.Text = Str(positivepulsewidth) & " uS"


        ' validate result


        If ((positivepulsewidth > 128) And (positivepulsewidth < 148)) Then
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' PASS'\n"))
            Led9.Value = True

        Else
            HP34970A.Write(ReplaceCommonEscapeSequences("DISP:TEXT ' FAIL'\n"))
            Led9.OffColor = Color.Red
        End If


        ' grab the screen and show in new window




    End Sub

    Private Sub Test10()

        ' this test will be done with a seies voltage devider resistor to get the voltage down 
        ' to below 300V.  Care will be needed to make sure the voltage never exceeds 300V even
        ' when the relay switch is open.



        ' Dim HP34970A As Device
        Dim response As String

        ' Let's start by turning the off color to Yellow to indicate the first test is running
        Led10.OffColor = Color.Yellow

        ' update screen
        Me.Refresh()


        ' connect and read voltage from 34401A

        TextBox1.Text = "Connecting to HP34401AA at Address 6" & vbCrLf
        TextBox1.Text = TextBox1.Text & "Sending *idn?" & vbCrLf


        ' use dio to set up kent's fixture.

        HP34970A = New Device(0, 9, 0)
        Try





            HP34970A.Write(ReplaceCommonEscapeSequences("*idn?\n"))


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



        ' read a response and place it on the text screen
        Try

            response = InsertCommonEscapeSequences(HP34970A.ReadString())

            TextBox1.Text = TextBox1.Text & "Response =" & response & vbCrLf


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            response = "NOCONNECT"
        End Try

        If (InStr(response, "HP34970") = 0) Then
            TextBox1.Text = TextBox1.Text & "Connected to HP34970A" & vbCrLf
        Else
            TextBox1.Text = TextBox1.Text & "Connection Error" & vbCrLf

            ' exit the test.
            MessageBox.Show(" Connection Error.  Please Check Your Setup.")
        End If


        ' set up switch for measurement
        TextBox1.Text = TextBox1.Text & "Setting up switch for DC voltage measurement" & vbCrLf
        HP34970A.Write(ReplaceCommonEscapeSequences("*RST\n"))  ' ISSUE FACTORY RESET OF INSTRUMENT

        ' power using 3V (RL4 closed)




        HP34970A.Write(ReplaceCommonEscapeSequences("SOURCE:DIGITAL:DATA:BYTE 181, (@201)\n"))  ' put under load - 3 vin



        HP34401A = New Device(0, 6, 0)

        Try





            HP34401A.Write(ReplaceCommonEscapeSequences("*idn?\n"))


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        ' read a response and place it on the text screen
        Try

            response = InsertCommonEscapeSequences(HP34401A.ReadString())

            TextBox1.Text = TextBox1.Text & "Response =" & response & vbCrLf


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            response = "NOCONNECT"
        End Try

        If (InStr(response, "34401A") <> 0) Then
            TextBox1.Text = TextBox1.Text & "Connected to HP34401A" & vbCrLf
        Else
            TextBox1.Text = TextBox1.Text & "Connection Error" & vbCrLf

            ' exit the test.
            MessageBox.Show(" Connection Error.  Please Check Your Setup.")
        End If



        ' measure and display
        HP34401A.Write(ReplaceCommonEscapeSequences("CONF:VOLT:DC 1000\n"))

        HP34401A.Write(ReplaceCommonEscapeSequences("SAMPLE:COUNT 1\n"))

        ' HP34401A.Write(ReplaceCommonEscapeSequences("TRIG:DELAY 5\n"))


        HP34401A.Write(ReplaceCommonEscapeSequences("TRIG:SOUR IMM\n"))

        MessageBox.Show("Press OK to Continue")

        ' MEASURE 5 TIMES
        ' Dim INDX As Integer


        ' HP34401A.Write(ReplaceCommonEscapeSequences("MEASURE:VOLT:DC?\n"))

        HP34401A.Write(ReplaceCommonEscapeSequences("READ?"))



        response = InsertCommonEscapeSequences(HP34401A.ReadString())




        ' format the string for display
        Dim highvoltage As Double
        highvoltage = Val(response)
        HVTP11 = highvoltage
        test10val = highvoltage



        Label23.Text = Str(highvoltage) & " V"



        ' validate measurement

        If (highvoltage > 470) And (highvoltage < 510) Then
            ' pass
            Led10.Value = True
            MessageBox.Show("Mark board as A grade")
        Else
            ' fail
            Led10.OffColor = Color.Red
            MessageBox.Show("Mark board as B grade")
        End If



        '---------------------------------------------


        Me.Refresh()
        Delay(1000)


    End Sub


    Private Function ReplaceCommonEscapeSequences(ByVal s As String) As String
        Return s.Replace("\n", ControlChars.Lf).Replace("\r", ControlChars.Cr)
    End Function 'ReplaceCommonEscapeSequences

    Private Function InsertCommonEscapeSequences(ByVal s As String) As String
        Return s.Replace(ControlChars.Lf, "\n").Replace(ControlChars.Cr, "\r")
    End Function 'InsertCommonEscapeSequences
    Public Sub Delay(ByVal Milliseconds As Integer)
        Dim SW2 As New Stopwatch
        SW2.Start()
        Do
            'Do not use this section to process code
            'We need this to check the elapsing time, as it
            'elapses without interuption\


        Loop Until SW2.ElapsedMilliseconds >= Milliseconds
    End Sub


End Class

