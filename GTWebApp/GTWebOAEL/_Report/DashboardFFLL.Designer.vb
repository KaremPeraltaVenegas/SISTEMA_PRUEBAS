Namespace Win_Dashboards
    Partial Public Class DashboardFFLL
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

#Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim StoredProcQuery1 As DevExpress.DataAccess.Sql.StoredProcQuery = New DevExpress.DataAccess.Sql.StoredProcQuery()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DashboardFFLL))
            Dim Dimension1 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim ColorSchemeEntry1 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim ColorSchemeEntry2 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim Measure1 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries2 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries3 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension3 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure4 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure5 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure6 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim PivotItemFormatRule1 As DevExpress.DashboardCommon.PivotItemFormatRule = New DevExpress.DashboardCommon.PivotItemFormatRule()
            Dim FormatConditionRangeSet1 As DevExpress.DashboardCommon.FormatConditionRangeSet = New DevExpress.DashboardCommon.FormatConditionRangeSet()
            Dim RangeInfo1 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim AppearanceSettings1 As DevExpress.DashboardCommon.AppearanceSettings = New DevExpress.DashboardCommon.AppearanceSettings()
            Dim RangeInfo2 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim AppearanceSettings2 As DevExpress.DashboardCommon.AppearanceSettings = New DevExpress.DashboardCommon.AppearanceSettings()
            Dim RangeInfo3 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim AppearanceSettings3 As DevExpress.DashboardCommon.AppearanceSettings = New DevExpress.DashboardCommon.AppearanceSettings()
            Dim RangeInfo4 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim AppearanceSettings4 As DevExpress.DashboardCommon.AppearanceSettings = New DevExpress.DashboardCommon.AppearanceSettings()
            Dim PivotItemFormatRule2 As DevExpress.DashboardCommon.PivotItemFormatRule = New DevExpress.DashboardCommon.PivotItemFormatRule()
            Dim FormatConditionRangeSet2 As DevExpress.DashboardCommon.FormatConditionRangeSet = New DevExpress.DashboardCommon.FormatConditionRangeSet()
            Dim RangeInfo5 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim IconSettings1 As DevExpress.DashboardCommon.IconSettings = New DevExpress.DashboardCommon.IconSettings()
            Dim RangeInfo6 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim IconSettings2 As DevExpress.DashboardCommon.IconSettings = New DevExpress.DashboardCommon.IconSettings()
            Dim RangeInfo7 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim IconSettings3 As DevExpress.DashboardCommon.IconSettings = New DevExpress.DashboardCommon.IconSettings()
            Dim PivotItemFormatRule3 As DevExpress.DashboardCommon.PivotItemFormatRule = New DevExpress.DashboardCommon.PivotItemFormatRule()
            Dim FormatConditionRangeSet3 As DevExpress.DashboardCommon.FormatConditionRangeSet = New DevExpress.DashboardCommon.FormatConditionRangeSet()
            Dim RangeInfo8 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim AppearanceSettings5 As DevExpress.DashboardCommon.AppearanceSettings = New DevExpress.DashboardCommon.AppearanceSettings()
            Dim RangeInfo9 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim AppearanceSettings6 As DevExpress.DashboardCommon.AppearanceSettings = New DevExpress.DashboardCommon.AppearanceSettings()
            Dim RangeInfo10 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim AppearanceSettings7 As DevExpress.DashboardCommon.AppearanceSettings = New DevExpress.DashboardCommon.AppearanceSettings()
            Dim Measure7 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure8 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure9 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure10 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ColorSchemeEntry3 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim ColorSchemeEntry4 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim ColorSchemeEntry5 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim ColorSchemeEntry6 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim ColorSchemeEntry7 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup2 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup3 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem3 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem4 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem5 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.DashboardSqlDataSource2 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.ComboBoxDashboardItem2 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.ChartDashboardItem1 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.PivotDashboardItem1 = New DevExpress.DashboardCommon.PivotDashboardItem()
            Me.PieDashboardItem1 = New DevExpress.DashboardCommon.PieDashboardItem()
            Me.PieDashboardItem2 = New DevExpress.DashboardCommon.PieDashboardItem()
            CType(Me.DashboardSqlDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PivotDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PieDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PieDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure9, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure10, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'DashboardSqlDataSource2
            '
            Me.DashboardSqlDataSource2.ComponentName = "DashboardSqlDataSource2"
            Me.DashboardSqlDataSource2.ConnectionName = "localhost_GTManpowerLocal_Connection 3"
            Me.DashboardSqlDataSource2.Name = "Origen de datos SQL 2"
            StoredProcQuery1.Name = "Query"
            StoredProcQuery1.StoredProcName = "SP_DHSB_FFLLResumen"
            Me.DashboardSqlDataSource2.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {StoredProcQuery1})
            Me.DashboardSqlDataSource2.ResultSchemaSerializable = resources.GetString("DashboardSqlDataSource2.ResultSchemaSerializable")
            '
            'ComboBoxDashboardItem2
            '
            Me.ComboBoxDashboardItem2.ComponentName = "ComboBoxDashboardItem2"
            Dimension1.DataMember = "cNomContrata"
            Me.ComboBoxDashboardItem2.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem2.DataItemRepository.Add(Dimension1, "DataItem0")
            Me.ComboBoxDashboardItem2.DataMember = "Query"
            Me.ComboBoxDashboardItem2.DataSource = Me.DashboardSqlDataSource2
            Me.ComboBoxDashboardItem2.EnableSearch = True
            Me.ComboBoxDashboardItem2.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension1})
            Me.ComboBoxDashboardItem2.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem2.Name = "Empresa"
            Me.ComboBoxDashboardItem2.ShowCaption = True
            '
            'ChartDashboardItem1
            '
            Dimension2.DataMember = "cPeriodo"
            Me.ChartDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension2})
            Me.ChartDashboardItem1.AxisX.TitleVisible = False
            ColorSchemeEntry1.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(6)
            ColorSchemeEntry1.DataMember = "Query"
            ColorSchemeEntry1.DataSource = Me.DashboardSqlDataSource2
            ColorSchemeEntry1.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("iLocal")})
            ColorSchemeEntry2.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(15)
            ColorSchemeEntry2.DataMember = "Query"
            ColorSchemeEntry2.DataSource = Me.DashboardSqlDataSource2
            ColorSchemeEntry2.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("iActivos")})
            Me.ChartDashboardItem1.ColorScheme.AddRange(New DevExpress.DashboardCommon.ColorSchemeEntry() {ColorSchemeEntry1, ColorSchemeEntry2})
            Me.ChartDashboardItem1.ComponentName = "ChartDashboardItem1"
            Measure1.DataMember = "iActivos"
            Measure1.Name = "Total Activos"
            Measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure1.NumericFormat.IncludeGroupSeparator = True
            Measure1.NumericFormat.Precision = 0
            Measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure2.DataMember = "iForaneo"
            Measure2.Name = "Foráneo"
            Measure2.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure2.NumericFormat.IncludeGroupSeparator = True
            Measure2.NumericFormat.Precision = 0
            Measure2.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure3.DataMember = "iLocal"
            Measure3.Name = "Local"
            Measure3.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure3.NumericFormat.IncludeGroupSeparator = True
            Measure3.NumericFormat.Precision = 0
            Measure3.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Me.ChartDashboardItem1.DataItemRepository.Clear()
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure1, "DataItem4")
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure2, "DataItem2")
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure3, "DataItem3")
            Me.ChartDashboardItem1.DataItemRepository.Add(Dimension2, "DataItem0")
            Me.ChartDashboardItem1.DataMember = "Query"
            Me.ChartDashboardItem1.DataSource = Me.DashboardSqlDataSource2
            Me.ChartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.ChartDashboardItem1.Name = "Evolución de Mano de Obra"
            ChartPane1.Name = "Panel 1"
            ChartPane1.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.PrimaryAxisY.ShowGridLines = True
            ChartPane1.PrimaryAxisY.TitleVisible = True
            ChartPane1.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.SecondaryAxisY.ShowGridLines = False
            ChartPane1.SecondaryAxisY.TitleVisible = True
            SimpleSeries1.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.SplineArea
            SimpleSeries1.AddDataItem("Value", Measure1)
            SimpleSeries2.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries2.ShowPointMarkers = True
            SimpleSeries2.AddDataItem("Value", Measure2)
            SimpleSeries3.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries3.ShowPointMarkers = True
            SimpleSeries3.AddDataItem("Value", Measure3)
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries1, SimpleSeries2, SimpleSeries3})
            Me.ChartDashboardItem1.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.ChartDashboardItem1.ShowCaption = True
            '
            'PivotDashboardItem1
            '
            Me.PivotDashboardItem1.ComponentName = "PivotDashboardItem1"
            Dimension3.DataMember = "cPeriodo"
            Dimension3.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            Measure4.DataMember = "iForaneo"
            Measure4.Name = "Foraneo"
            Measure4.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure4.NumericFormat.IncludeGroupSeparator = True
            Measure4.NumericFormat.Precision = 0
            Measure4.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure5.DataMember = "iLocal"
            Measure5.Name = "Local"
            Measure5.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure5.NumericFormat.IncludeGroupSeparator = True
            Measure5.NumericFormat.Precision = 0
            Measure5.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure6.DataMember = "iActivos"
            Measure6.Name = "Total"
            Measure6.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure6.NumericFormat.IncludeGroupSeparator = True
            Measure6.NumericFormat.Precision = 0
            Measure6.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Me.PivotDashboardItem1.DataItemRepository.Clear()
            Me.PivotDashboardItem1.DataItemRepository.Add(Dimension3, "DataItem2")
            Me.PivotDashboardItem1.DataItemRepository.Add(Measure4, "DataItem1")
            Me.PivotDashboardItem1.DataItemRepository.Add(Measure5, "DataItem3")
            Me.PivotDashboardItem1.DataItemRepository.Add(Measure6, "DataItem0")
            Me.PivotDashboardItem1.DataMember = "Query"
            Me.PivotDashboardItem1.DataSource = Me.DashboardSqlDataSource2
            PivotItemFormatRule1.ApplyToRow = True
            AppearanceSettings1.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.Red
            RangeInfo1.StyleSettings = AppearanceSettings1
            RangeInfo1.Value = 0.0R
            AppearanceSettings2.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.Yellow
            RangeInfo2.StyleSettings = AppearanceSettings2
            RangeInfo2.Value = 25.0R
            AppearanceSettings3.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.Green
            RangeInfo3.StyleSettings = AppearanceSettings3
            RangeInfo3.Value = 50.0R
            AppearanceSettings4.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.Blue
            RangeInfo4.StyleSettings = AppearanceSettings4
            RangeInfo4.Value = 75.0R
            FormatConditionRangeSet1.RangeSet.AddRange(New DevExpress.DashboardCommon.RangeInfo() {RangeInfo1, RangeInfo2, RangeInfo3, RangeInfo4})
            FormatConditionRangeSet1.ValueType = DevExpress.DashboardCommon.DashboardFormatConditionValueType.Percent
            PivotItemFormatRule1.Condition = FormatConditionRangeSet1
            PivotItemFormatRule1.DataItem = Measure6
            PivotItemFormatRule1.Enabled = False
            PivotItemFormatRule1.Name = "FormatRule 1"
            PivotItemFormatRule2.ApplyToRow = True
            IconSettings1.IconType = DevExpress.DashboardCommon.FormatConditionIconType.DirectionalRedTriangleDown
            RangeInfo5.StyleSettings = IconSettings1
            RangeInfo5.Value = 0.0R
            IconSettings2.IconType = DevExpress.DashboardCommon.FormatConditionIconType.DirectionalYellowDash
            RangeInfo6.StyleSettings = IconSettings2
            RangeInfo6.Value = 33.0R
            IconSettings3.IconType = DevExpress.DashboardCommon.FormatConditionIconType.DirectionalGreenTriangleUp
            RangeInfo7.StyleSettings = IconSettings3
            RangeInfo7.Value = 67.0R
            FormatConditionRangeSet2.RangeSet.AddRange(New DevExpress.DashboardCommon.RangeInfo() {RangeInfo5, RangeInfo6, RangeInfo7})
            FormatConditionRangeSet2.ValueType = DevExpress.DashboardCommon.DashboardFormatConditionValueType.Percent
            PivotItemFormatRule2.Condition = FormatConditionRangeSet2
            PivotItemFormatRule2.DataItem = Measure6
            PivotItemFormatRule2.Enabled = False
            PivotItemFormatRule2.Name = "FormatRule 2"
            PivotItemFormatRule3.ApplyToRow = True
            AppearanceSettings5.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.PaleRed
            RangeInfo8.StyleSettings = AppearanceSettings5
            RangeInfo8.Value = 0.0R
            AppearanceSettings6.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.PaleGreen
            RangeInfo9.StyleSettings = AppearanceSettings6
            RangeInfo9.Value = 33.0R
            AppearanceSettings7.AppearanceType = DevExpress.DashboardCommon.FormatConditionAppearanceType.PaleBlue
            RangeInfo10.StyleSettings = AppearanceSettings7
            RangeInfo10.Value = 67.0R
            FormatConditionRangeSet3.RangeSet.AddRange(New DevExpress.DashboardCommon.RangeInfo() {RangeInfo8, RangeInfo9, RangeInfo10})
            FormatConditionRangeSet3.ValueType = DevExpress.DashboardCommon.DashboardFormatConditionValueType.Percent
            PivotItemFormatRule3.Condition = FormatConditionRangeSet3
            PivotItemFormatRule3.DataItem = Measure6
            PivotItemFormatRule3.Name = "FormatRule 3"
            Me.PivotDashboardItem1.FormatRules.AddRange(New DevExpress.DashboardCommon.PivotItemFormatRule() {PivotItemFormatRule1, PivotItemFormatRule2, PivotItemFormatRule3})
            Me.PivotDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.PivotDashboardItem1.LayoutType = DevExpress.DashboardCommon.PivotLayoutType.Tabular
            Me.PivotDashboardItem1.Name = "Total por Periodo"
            Me.PivotDashboardItem1.Rows.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension3})
            Me.PivotDashboardItem1.ShowCaption = True
            Me.PivotDashboardItem1.ShowColumnGrandTotals = False
            Me.PivotDashboardItem1.ShowColumnTotals = False
            Me.PivotDashboardItem1.ShowRowGrandTotals = False
            Me.PivotDashboardItem1.ShowRowTotals = False
            Me.PivotDashboardItem1.Values.AddRange(New DevExpress.DashboardCommon.Measure() {Measure4, Measure5, Measure6})
            '
            'PieDashboardItem1
            '
            Me.PieDashboardItem1.ComponentName = "PieDashboardItem1"
            Measure7.DataMember = "iMOC"
            Measure7.Name = "MOC"
            Measure8.DataMember = "iMONC"
            Measure8.Name = "MONC"
            Me.PieDashboardItem1.DataItemRepository.Clear()
            Me.PieDashboardItem1.DataItemRepository.Add(Measure7, "DataItem0")
            Me.PieDashboardItem1.DataItemRepository.Add(Measure8, "DataItem1")
            Me.PieDashboardItem1.DataMember = "Query"
            Me.PieDashboardItem1.DataSource = Me.DashboardSqlDataSource2
            Me.PieDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.PieDashboardItem1.Name = "Tipo de Mano de Obra"
            Me.PieDashboardItem1.ShowCaption = True
            Me.PieDashboardItem1.Values.AddRange(New DevExpress.DashboardCommon.Measure() {Measure7, Measure8})
            '
            'PieDashboardItem2
            '
            Me.PieDashboardItem2.ComponentName = "PieDashboardItem2"
            Measure9.DataMember = "iMasculino"
            Measure9.Name = "Masculino"
            Measure10.DataMember = "iFemenino"
            Measure10.Name = "Femenino"
            Me.PieDashboardItem2.DataItemRepository.Clear()
            Me.PieDashboardItem2.DataItemRepository.Add(Measure9, "DataItem0")
            Me.PieDashboardItem2.DataItemRepository.Add(Measure10, "DataItem1")
            Me.PieDashboardItem2.DataMember = "Query"
            Me.PieDashboardItem2.DataSource = Me.DashboardSqlDataSource2
            Me.PieDashboardItem2.InteractivityOptions.IgnoreMasterFilters = False
            Me.PieDashboardItem2.Name = "Género"
            Me.PieDashboardItem2.ShowCaption = True
            Me.PieDashboardItem2.Values.AddRange(New DevExpress.DashboardCommon.Measure() {Measure9, Measure10})
            '
            'DashboardFFLL
            '
            ColorSchemeEntry3.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(System.Drawing.Color.FromArgb(-867524182))
            ColorSchemeEntry3.DataMember = "Query"
            ColorSchemeEntry3.DataSource = Me.DashboardSqlDataSource2
            ColorSchemeEntry3.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("iActivos")})
            ColorSchemeEntry4.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(System.Drawing.Color.FromArgb(-12498330))
            ColorSchemeEntry4.DataMember = "Query"
            ColorSchemeEntry4.DataSource = Me.DashboardSqlDataSource2
            ColorSchemeEntry4.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("iLocal")})
            ColorSchemeEntry5.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(1)
            ColorSchemeEntry5.DataMember = "Query"
            ColorSchemeEntry5.DataSource = Me.DashboardSqlDataSource2
            ColorSchemeEntry5.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("iForaneo")})
            ColorSchemeEntry6.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(7)
            ColorSchemeEntry6.DataMember = "Query"
            ColorSchemeEntry6.DataSource = Me.DashboardSqlDataSource2
            ColorSchemeEntry6.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("iFemenino")})
            ColorSchemeEntry7.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(6)
            ColorSchemeEntry7.DataMember = "Query"
            ColorSchemeEntry7.DataSource = Me.DashboardSqlDataSource2
            ColorSchemeEntry7.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("iMasculino")})
            Me.ColorScheme.AddRange(New DevExpress.DashboardCommon.ColorSchemeEntry() {ColorSchemeEntry3, ColorSchemeEntry4, ColorSchemeEntry5, ColorSchemeEntry6, ColorSchemeEntry7})
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.DashboardSqlDataSource2})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.ChartDashboardItem1, Me.PieDashboardItem1, Me.PieDashboardItem2, Me.PivotDashboardItem1, Me.ComboBoxDashboardItem2})
            DashboardLayoutItem1.DashboardItem = Me.ComboBoxDashboardItem2
            DashboardLayoutItem1.Weight = 17.888198757763973R
            DashboardLayoutItem2.DashboardItem = Me.ChartDashboardItem1
            DashboardLayoutItem2.Weight = 82.111801242236027R
            DashboardLayoutGroup2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2})
            DashboardLayoutGroup2.DashboardItem = Nothing
            DashboardLayoutGroup2.Weight = 54.662379421221864R
            DashboardLayoutItem3.DashboardItem = Me.PivotDashboardItem1
            DashboardLayoutItem3.Weight = 32.298136645962735R
            DashboardLayoutItem4.DashboardItem = Me.PieDashboardItem1
            DashboardLayoutItem4.Weight = 34.161490683229815R
            DashboardLayoutItem5.DashboardItem = Me.PieDashboardItem2
            DashboardLayoutItem5.Weight = 33.54037267080745R
            DashboardLayoutGroup3.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem3, DashboardLayoutItem4, DashboardLayoutItem5})
            DashboardLayoutGroup3.DashboardItem = Nothing
            DashboardLayoutGroup3.Weight = 45.337620578778136R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup2, DashboardLayoutGroup3})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.ShowMasterFilterState = False
            Me.Title.Text = "Fuerza Laboral Historial"
            CType(Me.DashboardSqlDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboBoxDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PivotDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PieDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure9, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure10, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PieDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents ChartDashboardItem1 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents DashboardSqlDataSource2 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents PivotDashboardItem1 As DevExpress.DashboardCommon.PivotDashboardItem
        Friend WithEvents ComboBoxDashboardItem2 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents PieDashboardItem2 As DevExpress.DashboardCommon.PieDashboardItem
        Friend WithEvents PieDashboardItem1 As DevExpress.DashboardCommon.PieDashboardItem

#End Region
    End Class
End Namespace