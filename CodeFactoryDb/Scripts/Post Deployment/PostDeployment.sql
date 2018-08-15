--=======================================================
--Table Options
--=======================================================

--EXEC sp_tableoption @TableNamePattern =  N'[StreamReceivedBTS]' 
--     ,@OptionName = N'large value types out of row' 
--     ,@OptionValue = N'1';

--EXEC sp_tableoption @TableNamePattern =  N'[StreamDeliverRetryBTS]' 
--     ,@OptionName = N'large value types out of row' 
--     ,@OptionValue = N'1';


:r .\Assemblies\Assembly.sql
:r .\Data\CodeSetData.sql
:r .\Data\UserData.sql
:r .\Data\UserCredentialData.sql
--:r D:\Development\CodeFactory\CodeFactoryDb\CodeFactoryDb\Scripts\Post Deployment\PostDeployment.sql.\Users.sql
--:r .\RoleMemberships.sql
--:r .\Permissions.sql

--:r .\Data\MetaData.sql
--:r .\Data\ETLControl.sql

----:r .\Data\StreamTypeData.sql
--:r .\Data\PartitionedTablesMetadata.sql

--:r .\Partitioning.sql

--:r .\DropLinkServer.sql

--:r .\Jobs\OperationalStoreDbConvertUnPartitonedTablesToPartitioned.sql
--:r .\Jobs\OperationalStoreDbRollingWindowForPartitionedTables.sql
--:r .\Jobs\OperationalDataSourceETLDataExtractor.sql
--:r .\Jobs\TrackingETL.sql
--:r .\Jobs\DataLatencyAlert.sql
--:r .\Jobs\CorrelateFunctionalAck.sql
--:r .\Jobs\AlertingToOdsDataSyncJob.sql
--:r .\Jobs\OperationalDataStoreDbAcquisitionMonitorJob.sql
--:r .\EnableEncryption.sql

