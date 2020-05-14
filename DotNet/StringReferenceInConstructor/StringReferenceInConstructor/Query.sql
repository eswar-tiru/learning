exec pr_ConfigurationConsole_SaveConfigurationSetting @username = '*', @appname = 'Eze.OperationsService.Svc.exe',@machinename = '*',@settinggroup = 'Raw XML',@settingname = 'loggingConfiguration', @settingvalue = '<?xml version="1.0" encoding="utf-8"?>
<loggingConfiguration name="Logging Application Block" tracingEnabled="true" defaultCategory="General" logWarningsWhenNoCategoriesMatch="true">
	<categorySources>
		<add name="General" switchValue="All">
	    	<listeners>
                <add name="EventLogSinkData" />
                <add name="FlatFileSinkData" />
            </listeners>
        </add>
		<add name="Networking" switchValue="All" />
		<add switchValue="All" name="Audit">
			<listeners>
                <add name="DatabaseSinkData" />
                <add name="EventLogSinkData" />
            </listeners>
        </add>
		<add switchValue="All" name="Debug">
            <listeners>
                <add name="FlatFileSinkData" />
            </listeners>
        </add>			
		<add switchValue="All" name="System">
			<listeners>
                <add name="EventLogSinkData" />
                <add name="FlatFileSinkData" />
            </listeners>
        </add>
	</categorySources>
	<listeners>
		<add name="DatabaseSinkData" databaseInstanceName="SQL Connection String" writeLogStoredProcName="pr_n_InsertAudit" addCategoryStoredProcName="AddCategory" formatter="Text Formatter" listenerDataType="ECS.Common.Utils.Logging.EzeDatabaseTraceListenerData, ECS.Common.Utils.Logging" traceOutputOptions="None" type="ECS.Common.Utils.Logging.EzeDatabaseTraceListener, ECS.Common.Utils.Logging" />
		<add name="EventLogSinkData" source="Eze Operations Service" formatter="Block-Style Text Formatter" log="Application" machineName="" listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.FormattedEventLogTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging" traceOutputOptions="None" type="ECS.Common.Utils.Logging.EzeEventLogTraceListener, ECS.Common.Utils.Logging" />
		<add name="FlatFileSinkData" fileName="Logs\Eze.OperationsService.log" formatter="Brief Inline Formatter" listenerDataType="ECS.Common.Utils.Logging.CappedRollingFileListenerData, ECS.Common.Utils.Logging" traceOutputOptions="None" type="ECS.Common.Utils.Logging.CappedRollingFileListener, ECS.Common.Utils.Logging" rollSizeKB="50000" rollInterval="Day" archiveDepth="10" timeStampPattern="yyyy-MM-dd.[hh][mm]" />
	</listeners>
	<formatters>
		<add name="Text Formatter" template="Timestamp: {timestamp}&#xD;&#xA;Message: {message}&#xD;&#xA;User: {userID}&#xD;&#xA;Category: {category}&#xD;&#xA;Severity: {severity}&#xD;&#xA;Subsystem:{subsystem}&#xD;&#xA;Symbol:{symbol}&#xD;&#xA;TradeIC:{tradeID}&#xD;&#xA;Machine: {machine}&#xD;&#xA;Stack: {callStack}&#xD;&#xA;Application Domain: {appDomain}&#xD;&#xA;Process IC: {processId}&#xD;&#xA;Process Name: {processName}&#xD;&#xA;Win32 Thread IC: {win32ThreadId}&#xD;&#xA;Thread Name: {threadName}&#xD;&#xA;Extended Properties: {dictionary({key} - {value}&#xD;&#xA;)}" type="ECS.Common.Utils.Logging.EzeTextFormatter, ECS.Common.Utils.Logging" />
        <add name="Block-Style Text Formatter" type="ECS.Common.Utils.Logging.EzeTextFormatter, ECS.Common.Utils.Logging" template="Timestamp: {timestamp(local)}  Message: {message}  Category: {category}  Severity: {severity}  Machine: {machine}  Process IC: {processId}  Process Name: {processName}  )}" />
        <add name="Brief Inline Formatter" type="ECS.Common.Utils.Logging.EzeTextFormatter, ECS.Common.Utils.Logging" template="{timestamp(local)}{tab}{message}{tab}{category}{tab}{severity}{tab}{machine}{tab}{processId}{tab}{processName}" />
        <add name="DebugView Formatter" type="ECS.Common.Utils.Logging.EzeTextFormatter, ECS.Common.Utils.Logging" template="{severity}{tab}{message}{tab}{machine}{tab}{processName}" />
	</formatters>
	<specialSources>
		<allEvents switchValue="All" name="All Events"><listeners><add name="FlatFileSinkData" /></listeners></allEvents>
		<notProcessed switchValue="All" name="Unprocessed Category" />
		<errors switchValue="All" name="Logging Errors &amp; Warnings">
			<listeners>
                <add name="EventLogSinkData" />
                <add name="FlatFileSinkData" />
            </listeners>
        </errors>
	</specialSources>
</loggingConfiguration>'