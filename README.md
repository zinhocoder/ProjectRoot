# ProjectRoot
API Desafio DEV

dotnet : Unhandled exception. Microsoft.Data.SqlClient.SqlException (0x80131904): Falha de logon do usu├írio 'DESKTOP-UPK3FI1\Testes'.
No linha:1 caractere:1
+ dotnet run
+ ~~~~~~~~~~
    + CategoryInfo          : NotSpecified: (Unhandled excep...PK3FI1\Testes'.:String) [], RemoteException
    + FullyQualifiedErrorId : NativeCommandError
 
   at Microsoft.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at Microsoft.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, 
TdsParserStateObject stateObj, Boolean& dataReady)
   at Microsoft.Data.SqlClient.TdsParser.Run(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, 
TdsParserStateObject stateObj)
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.CompleteLogin(Boolean enlistOK)
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.LoginNoFailover(ServerInfo serverInfo, String newPassword, SecureString newSecurePassword, Boolean 
redirectedUserInstance, SqlConnectionString connectionOptions, SqlCredential credential, TimeoutTimer timeout)
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds.OpenLoginEnlist(TimeoutTimer timeout, SqlConnectionString connectionOptions, SqlCredential credential, 
String newPassword, SecureString newSecurePassword, Boolean redirectedUserInstance)
   at Microsoft.Data.SqlClient.SqlInternalConnectionTds..ctor(DbConnectionPoolIdentity identity, SqlConnectionString connectionOptions, SqlCredential credential, 
Object providerInfo, String newPassword, SecureString newSecurePassword, Boolean redirectedUserInstance, SqlConnectionString userConnectionOptions, SessionData 
reconnectSessionData, Boolean applyTransientFaultHandling, String accessToken, DbConnectionPool pool)
   at Microsoft.Data.SqlClient.SqlConnectionFactory.CreateConnection(DbConnectionOptions options, DbConnectionPoolKey poolKey, Object poolGroupProviderInfo, 
DbConnectionPool pool, DbConnection owningConnection, DbConnectionOptions userOptions)
   at Microsoft.Data.ProviderBase.DbConnectionPool.CreateObject(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection)
   at Microsoft.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, UInt32 waitForMultipleObjectsTimeout, Boolean allowCreate, Boolean 
onlyOneCheckConnection, DbConnectionOptions userOptions, DbConnectionInternal& connection)
   at Microsoft.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, 
DbConnectionInternal& connection)
   at Microsoft.Data.ProviderBase.DbConnectionFactory.TryGetConnection(DbConnection owningConnection, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, 
DbConnectionInternal oldConnection, DbConnectionInternal& connection)
   at Microsoft.Data.ProviderBase.DbConnectionInternal.TryOpenConnectionInternal(DbConnection outerConnection, DbConnectionFactory connectionFactory, 
TaskCompletionSource`1 retry, DbConnectionOptions userOptions)
   at Microsoft.Data.SqlClient.SqlConnection.TryOpen(TaskCompletionSource`1 retry, SqlConnectionOverrides overrides)
   at Microsoft.Data.SqlClient.SqlConnection.Open(SqlConnectionOverrides overrides)
   at Microsoft.EntityFrameworkCore.Storage.RelationalConnection.OpenInternal(Boolean errorsExpected)
   at Microsoft.EntityFrameworkCore.Storage.RelationalConnection.Open(Boolean errorsExpected)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerDatabaseCreator.<>c__DisplayClass18_0.<Exists>b__0(DateTime giveUp)
   at Microsoft.EntityFrameworkCore.ExecutionStrategyExtensions.<>c__DisplayClass12_0`2.<Execute>b__0(DbContext _, TState s)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 
verifySucceeded)
   at Microsoft.EntityFrameworkCore.ExecutionStrategyExtensions.Execute[TState,TResult](IExecutionStrategy strategy, TState state, Func`2 operation, Func`2 
verifySucceeded)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerDatabaseCreator.Exists(Boolean retryOnNotExists)
   at Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal.SqlServerDatabaseCreator.Exists()
   at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.Migrate(String targetMigration)
   at Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.Migrate(DatabaseFacade databaseFacade)
   at Program.<Main>$(String[] args) in C:\Users\Testes\Downloads\ProjectRoot-main (1)\ProjectRoot-main\Program.cs:line 54
ClientConnectionId:6f070c6c-ad6d-429f-b113-e87a83918e3e
Error Number:18456,State:1,Class:14
