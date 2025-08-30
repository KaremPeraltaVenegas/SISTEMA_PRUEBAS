Namespace Win_Dashboards
    Partial Public Class DashboardPGIAnexoAdmisionResumen
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
            Dim CustomSqlQuery1 As DevExpress.DataAccess.Sql.CustomSqlQuery = New DevExpress.DataAccess.Sql.CustomSqlQuery()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DashboardPGIAnexoAdmisionResumen))
            Dim Dimension1 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim ColorSchemeEntry1 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim ColorSchemeEntry2 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim Measure1 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries2 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure4 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ColorSchemeEntry3 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim ColorSchemeEntry4 As DevExpress.DashboardCommon.ColorSchemeEntry = New DevExpress.DashboardCommon.ColorSchemeEntry()
            Dim Measure5 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure6 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure7 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure8 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup2 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup3 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem3 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem4 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem5 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.DashboardSqlDataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.ListBoxDashboardItem1 = New DevExpress.DashboardCommon.ListBoxDashboardItem()
            Me.ChartDashboardItem1 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.PieDashboardItem1 = New DevExpress.DashboardCommon.PieDashboardItem()
            Me.PieDashboardItem2 = New DevExpress.DashboardCommon.PieDashboardItem()
            Me.PieDashboardItem3 = New DevExpress.DashboardCommon.PieDashboardItem()
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ListBoxDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PieDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PieDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PieDashboardItem3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'DashboardSqlDataSource1
            '
            Me.DashboardSqlDataSource1.ComponentName = "DashboardSqlDataSource1"
            Me.DashboardSqlDataSource1.ConnectionName = "ecs-idn.GTManpowerLocalsss.dbo"
            Me.DashboardSqlDataSource1.Name = "Origen de datos SQL 1"
            CustomSqlQuery1.Name = "Query"
            CustomSqlQuery1.Sql = "select * from m_DashboardPGIAnexoAdmisionResumen"
            Me.DashboardSqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {CustomSqlQuery1})
            Me.DashboardSqlDataSource1.ResultSchemaSerializable = resources.GetString("DashboardSqlDataSource1.ResultSchemaSerializable")
            '
            'ListBoxDashboardItem1
            '
            Me.ListBoxDashboardItem1.ComponentName = "ListBoxDashboardItem1"
            Dimension1.DataMember = "cNomCorto"
            Dimension1.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            Me.ListBoxDashboardItem1.DataItemRepository.Clear()
            Me.ListBoxDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem0")
            Me.ListBoxDashboardItem1.DataMember = "Query"
            Me.ListBoxDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.ListBoxDashboardItem1.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension1})
            Me.ListBoxDashboardItem1.InteractivityOptions.IgnoreMasterFilters = True
            Me.ListBoxDashboardItem1.Name = "Nombre de la Empresa"
            Me.ListBoxDashboardItem1.ShowCaption = True
            '
            'ChartDashboardItem1
            '
            Dimension2.DataMember = "dFechaSolicitud"
            Dimension2.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            Me.ChartDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension2})
            Me.ChartDashboardItem1.AxisX.TitleVisible = False
            Me.ChartDashboardItem1.ColoringOptions.MeasuresColoringMode = DevExpress.DashboardCommon.ColoringMode.Hue
            ColorSchemeEntry1.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(0)
            ColorSchemeEntry1.DataMember = "Query"
            ColorSchemeEntry1.DataSource = Me.DashboardSqlDataSource1
            ColorSchemeEntry1.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("iForaneo")})
            ColorSchemeEntry2.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(1)
            ColorSchemeEntry2.DataMember = "Query"
            ColorSchemeEntry2.DataSource = Me.DashboardSqlDataSource1
            ColorSchemeEntry2.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("iLocal")})
            Me.ChartDashboardItem1.ColorScheme.AddRange(New DevExpress.DashboardCommon.ColorSchemeEntry() {ColorSchemeEntry1, ColorSchemeEntry2})
            Me.ChartDashboardItem1.ComponentName = "ChartDashboardItem1"
            Measure1.DataMember = "iLocal"
            Measure1.Name = "Locales"
            Measure2.DataMember = "iForaneo"
            Measure2.Name = "Foraneos"
            Me.ChartDashboardItem1.DataItemRepository.Clear()
            Me.ChartDashboardItem1.DataItemRepository.Add(Dimension2, "DataItem0")
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure1, "DataItem2")
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure2, "DataItem1")
            Me.ChartDashboardItem1.DataMember = "Query"
            Me.ChartDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.ChartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.ChartDashboardItem1.Name = "Evolución de Tendencia ( Locales - Foraneos)"
            ChartPane1.Name = "Panel 1"
            ChartPane1.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.PrimaryAxisY.ShowGridLines = True
            ChartPane1.PrimaryAxisY.TitleVisible = True
            ChartPane1.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.SecondaryAxisY.ShowGridLines = False
            ChartPane1.SecondaryAxisY.TitleVisible = True
            SimpleSeries1.PointLabelOptions.ContentType = DevExpress.DashboardCommon.PointLabelContentTypeEx.Value
            SimpleSeries1.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries1.ShowPointMarkers = True
            SimpleSeries1.AddDataItem("Value", Measure2)
            SimpleSeries2.PointLabelOptions.ContentType = DevExpress.DashboardCommon.PointLabelContentTypeEx.Value
            SimpleSeries2.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.Line
            SimpleSeries2.ShowPointMarkers = True
            SimpleSeries2.AddDataItem("Value", Measure1)
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries1, SimpleSeries2})
            Me.ChartDashboardItem1.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.ChartDashboardItem1.ShowCaption = True
            '
            'PieDashboardItem1
            '
            Me.PieDashboardItem1.ComponentName = "PieDashboardItem1"
            Measure3.DataMember = "iForaneo"
            Measure3.Name = "Foraneo"
            Measure4.DataMember = "iLocal"
            Measure4.Name = "Local"
            Me.PieDashboardItem1.DataItemRepository.Clear()
            Me.PieDashboardItem1.DataItemRepository.Add(Measure3, "DataItem0")
            Me.PieDashboardItem1.DataItemRepository.Add(Measure4, "DataItem1")
            Me.PieDashboardItem1.DataMember = "Query"
            Me.PieDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.PieDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.PieDashboardItem1.Name = "Estadística por Condición"
            Me.PieDashboardItem1.PieType = DevExpress.DashboardCommon.PieType.Donut
            Me.PieDashboardItem1.ShowCaption = True
            Me.PieDashboardItem1.Values.AddRange(New DevExpress.DashboardCommon.Measure() {Measure3, Measure4})
            '
            'PieDashboardItem2
            '
            ColorSchemeEntry3.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(19)
            ColorSchemeEntry3.DataMember = "Query"
            ColorSchemeEntry3.DataSource = Me.DashboardSqlDataSource1
            ColorSchemeEntry3.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("iMOC")})
            ColorSchemeEntry4.ColorDefinition = New DevExpress.DashboardCommon.ColorDefinition(1)
            ColorSchemeEntry4.DataMember = "Query"
            ColorSchemeEntry4.DataSource = Me.DashboardSqlDataSource1
            ColorSchemeEntry4.MeasureKey = New DevExpress.DashboardCommon.ColorSchemeMeasureKey(New DevExpress.DashboardCommon.MeasureDefinition() {New DevExpress.DashboardCommon.MeasureDefinition("iMONC")})
            Me.PieDashboardItem2.ColorScheme.AddRange(New DevExpress.DashboardCommon.ColorSchemeEntry() {ColorSchemeEntry3, ColorSchemeEntry4})
            Me.PieDashboardItem2.ComponentName = "PieDashboardItem2"
            Measure5.DataMember = "iMOC"
            Measure5.Name = "MOC"
            Measure6.DataMember = "iMONC"
            Measure6.Name = "MONC"
            Me.PieDashboardItem2.DataItemRepository.Clear()
            Me.PieDashboardItem2.DataItemRepository.Add(Measure5, "DataItem0")
            Me.PieDashboardItem2.DataItemRepository.Add(Measure6, "DataItem1")
            Me.PieDashboardItem2.DataMember = "Query"
            Me.PieDashboardItem2.DataSource = Me.DashboardSqlDataSource1
            Me.PieDashboardItem2.InteractivityOptions.IgnoreMasterFilters = False
            Me.PieDashboardItem2.Name = "Estadística de MOC - MONC"
            Me.PieDashboardItem2.PieType = DevExpress.DashboardCommon.PieType.Donut
            Me.PieDashboardItem2.ShowCaption = True
            Me.PieDashboardItem2.Values.AddRange(New DevExpress.DashboardCommon.Measure() {Measure5, Measure6})
            '
            'PieDashboardItem3
            '
            Me.PieDashboardItem3.ComponentName = "PieDashboardItem3"
            Measure7.DataMember = "iSexoF"
            Measure7.Name = "Femenino"
            Measure8.DataMember = "iSexoM"
            Measure8.Name = "Masculino"
            Me.PieDashboardItem3.DataItemRepository.Clear()
            Me.PieDashboardItem3.DataItemRepository.Add(Measure7, "DataItem0")
            Me.PieDashboardItem3.DataItemRepository.Add(Measure8, "DataItem1")
            Me.PieDashboardItem3.DataMember = "Query"
            Me.PieDashboardItem3.DataSource = Me.DashboardSqlDataSource1
            Me.PieDashboardItem3.InteractivityOptions.IgnoreMasterFilters = False
            Me.PieDashboardItem3.Name = "Estadística por Género"
            Me.PieDashboardItem3.PieType = DevExpress.DashboardCommon.PieType.Donut
            Me.PieDashboardItem3.ShowCaption = True
            Me.PieDashboardItem3.Values.AddRange(New DevExpress.DashboardCommon.Measure() {Measure7, Measure8})
            '
            'DashboardPGIAnexoAdmisionResumen
            '
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.DashboardSqlDataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.PieDashboardItem1, Me.PieDashboardItem2, Me.ListBoxDashboardItem1, Me.PieDashboardItem3, Me.ChartDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.ListBoxDashboardItem1
            DashboardLayoutItem1.Weight = 16.851063829787233R
            DashboardLayoutItem2.DashboardItem = Me.ChartDashboardItem1
            DashboardLayoutItem2.Weight = 64.828897338403038R
            DashboardLayoutItem3.DashboardItem = Me.PieDashboardItem1
            DashboardLayoutItem3.Weight = 35.72159672466735R
            DashboardLayoutItem4.DashboardItem = Me.PieDashboardItem2
            DashboardLayoutItem4.Weight = 31.320368474923235R
            DashboardLayoutItem5.DashboardItem = Me.PieDashboardItem3
            DashboardLayoutItem5.Weight = 32.958034800409415R
            DashboardLayoutGroup3.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem3, DashboardLayoutItem4, DashboardLayoutItem5})
            DashboardLayoutGroup3.DashboardItem = Nothing
            DashboardLayoutGroup3.Weight = 35.171102661596962R
            DashboardLayoutGroup2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem2, DashboardLayoutGroup3})
            DashboardLayoutGroup2.DashboardItem = Nothing
            DashboardLayoutGroup2.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup2.Weight = 83.148936170212764R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutGroup2})
            DashboardLayoutGroup1.DashboardItem = Nothing
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.Text = "Dashboard - PGI Resumen"
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ListBoxDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PieDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PieDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PieDashboardItem3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents DashboardSqlDataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents PieDashboardItem1 As DevExpress.DashboardCommon.PieDashboardItem
        Friend WithEvents ListBoxDashboardItem1 As DevExpress.DashboardCommon.ListBoxDashboardItem
        Friend WithEvents PieDashboardItem3 As DevExpress.DashboardCommon.PieDashboardItem
        Friend WithEvents PieDashboardItem2 As DevExpress.DashboardCommon.PieDashboardItem
        Friend WithEvents ChartDashboardItem1 As DevExpress.DashboardCommon.ChartDashboardItem

#End Region
    End Class
End Namespace