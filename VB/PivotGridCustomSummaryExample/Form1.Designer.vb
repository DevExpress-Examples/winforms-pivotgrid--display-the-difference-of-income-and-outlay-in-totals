Namespace PivotGridCustomSummaryExample
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.pivotGridControl1 = New DevExpress.XtraPivotGrid.PivotGridControl()
			Me.testDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.fieldName = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldDate = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldValue = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.fieldType = New DevExpress.XtraPivotGrid.PivotGridField()
			Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
			Me.toggleOptimizedMode = New DevExpress.XtraEditors.ToggleSwitch()
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			DirectCast(Me.pivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.testDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelControl1.SuspendLayout()
			DirectCast(Me.toggleOptimizedMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' pivotGridControl1
			' 
			Me.pivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default
			Me.pivotGridControl1.DataSource = Me.testDataBindingSource
			Me.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.pivotGridControl1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() { Me.fieldName, Me.fieldDate, Me.fieldValue, Me.fieldType})
			Me.pivotGridControl1.Location = New System.Drawing.Point(0, 37)
			Me.pivotGridControl1.Name = "pivotGridControl1"
			Me.pivotGridControl1.Size = New System.Drawing.Size(678, 251)
			Me.pivotGridControl1.TabIndex = 0
			' 
			' testDataBindingSource
			' 
			Me.testDataBindingSource.DataSource = GetType(PivotGridCustomSummaryExample.TestData)
			' 
			' fieldName
			' 
			Me.fieldName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
			Me.fieldName.AreaIndex = 0
			Me.fieldName.Caption = "Name"
			Me.fieldName.FieldName = "Name"
			Me.fieldName.Name = "fieldName"
			' 
			' fieldDate
			' 
			Me.fieldDate.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
			Me.fieldDate.AreaIndex = 0
			Me.fieldDate.Caption = "Date"
			Me.fieldDate.FieldName = "Date"
			Me.fieldDate.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonthYear
			Me.fieldDate.Name = "fieldDate"
			Me.fieldDate.UnboundFieldName = "fieldDate"
			' 
			' fieldValue
			' 
			Me.fieldValue.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
			Me.fieldValue.AreaIndex = 0
			Me.fieldValue.Caption = "Value"
			Me.fieldValue.FieldName = "Value"
			Me.fieldValue.Name = "fieldValue"
			' 
			' fieldType
			' 
			Me.fieldType.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
			Me.fieldType.AreaIndex = 1
			Me.fieldType.Caption = "Type"
			Me.fieldType.FieldName = "Type"
			Me.fieldType.Name = "fieldType"
			' 
			' panelControl1
			' 
			Me.panelControl1.Controls.Add(Me.toggleOptimizedMode)
			Me.panelControl1.Controls.Add(Me.labelControl1)
			Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panelControl1.Location = New System.Drawing.Point(0, 0)
			Me.panelControl1.Name = "panelControl1"
			Me.panelControl1.Size = New System.Drawing.Size(678, 37)
			Me.panelControl1.TabIndex = 1
			' 
			' toggleOptimizedMode
			' 
			Me.toggleOptimizedMode.Location = New System.Drawing.Point(96, 7)
			Me.toggleOptimizedMode.Name = "toggleOptimizedMode"
			Me.toggleOptimizedMode.Properties.OffText = "Off"
			Me.toggleOptimizedMode.Properties.OnText = "On"
			Me.toggleOptimizedMode.Size = New System.Drawing.Size(95, 18)
			Me.toggleOptimizedMode.TabIndex = 1
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.toggleOptimizedMode.Toggled += new System.EventHandler(this.toggleOptimizedMode_Toggled);
			' 
			' labelControl1
			' 
			Me.labelControl1.Location = New System.Drawing.Point(10, 9)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Size = New System.Drawing.Size(80, 13)
			Me.labelControl1.TabIndex = 0
			Me.labelControl1.Text = "Optimized mode:"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(678, 288)
			Me.Controls.Add(Me.pivotGridControl1)
			Me.Controls.Add(Me.panelControl1)
			Me.Name = "Form1"
			Me.Text = "Custom Summary Example"
			DirectCast(Me.pivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.testDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelControl1.ResumeLayout(False)
			Me.panelControl1.PerformLayout()
			DirectCast(Me.toggleOptimizedMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private pivotGridControl1 As DevExpress.XtraPivotGrid.PivotGridControl
		Private panelControl1 As DevExpress.XtraEditors.PanelControl
		Private WithEvents toggleOptimizedMode As DevExpress.XtraEditors.ToggleSwitch
		Private labelControl1 As DevExpress.XtraEditors.LabelControl
		Private testDataBindingSource As System.Windows.Forms.BindingSource
		Private fieldName As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldDate As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldValue As DevExpress.XtraPivotGrid.PivotGridField
		Private fieldType As DevExpress.XtraPivotGrid.PivotGridField
	End Class
End Namespace

