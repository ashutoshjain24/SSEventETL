using System;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using SSEventsETL.Utility;
using SSEventsETL.DomainModel;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Transactions;


namespace SSEventsETL.Helpers
{
    public static class DatabaseHelper
    {
        static readonly string AccessTokenTable = ConfigurationManager.AppSettings["AccessTokenTable"];

        public static int? InsertCallLogInToDatabse(CallLog callLog)
        {
            int? databasekey;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ToString()))
            {
                //log.Info("Open SQL Connection");

                connection.Open();

                try
                {
                    var sqlstatement = @"Insert into SS_EVENT_CAPTURE (STARTTIME,REQUEST,RESPONSE,ENDTIME,NEXTSTREAMPOSITION,MOREAVAILABLE,AUDTINSTTS,AUDTUPDTTS,COMPLETIONSTATUS, EVENTCOUNT, ResponseCode) Values(@STARTTIME, @REQUEST, @RESPONSE, @ENDTIME, @NEXTSTREAMPOSITION, @MOREAVAILABLE, @AUDTINSTTS, @AUDTUPDTTS, @COMPLETIONSTATUS,@EVENTCOUNT,@RESPONSECODE); Select Cast(SCOPE_IDENTITY() As int);";
                    // connection.Execute(sqlstatement, new { STARTTIME = callLog.StartTime, REQUEST = callLog.Request, RESPONSE = callLog.Response, ENDTIME = callLog.EndTime, NEXTSTREAMPOSITION = callLog.PayLoad.NextStreamPosition, MOREAVAILABLE = callLog.PayLoad.MoreAvailable, AUDTINSTTS = DateTime.Now, AUDTUPDTTS = DateTime.Now, COMPLETIONSTATUS = "0", EVENTCOUNT = callLog.PayLoad.EventCount, RESPONSECODE = callLog.ResponseCode });
                    databasekey = connection.Query<int>(sqlstatement, new
                    {
                        STARTTIME = callLog.StartTime,
                        REQUEST = callLog.Request,
                        RESPONSE = callLog.Response,
                        ENDTIME = callLog.EndTime,
                        NEXTSTREAMPOSITION = callLog.PayLoad.NextStreamPosition,
                        MOREAVAILABLE = callLog.PayLoad.MoreAvailable,
                        AUDTINSTTS = DateTime.Now,
                        AUDTUPDTTS = DateTime.Now,
                        COMPLETIONSTATUS = "0",
                        EVENTCOUNT = callLog.PayLoad.EventCount,
                        RESPONSECODE = callLog.ResponseCode
                    }).Single();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            // FileUtility.WriteToFile(Environment.CurrentDirectory + FileUtility.GetItFromAppConfig("NextStreamPositionFilePath"), callLog.PayLoad.NextStreamPosition);

            UpdateNextPositionVal(callLog.PayLoad.NextStreamPosition);
            return databasekey;

        }

        public static List<KeyValuePair<string, string>> GetTableMappingFromDatabase(string dbConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                connection.Open();

                var sql = @"Select OBJECTTYPE , TABLENAME from SS_OBJECT_TABLE_MAPPING";
                var datax = connection.Query(sql);
                List<KeyValuePair<string, string>> KVPList = new List<KeyValuePair<string, string>>();

                foreach(var x in datax)
                {
                    KVPList.Add(new KeyValuePair<string, string>( x.OBJECTTYPE, x.TABLENAME));
                }

                return KVPList;
            }
        }

        public static InputStream GetFromTheDatabase(string dbConnectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dbConnectionString))
                {
                    //log.Info("Open SQL Connection");

                    connection.Open();

                    var sqlstatement = @"SELECT TOP 1 NEXTSTREAMPOSITION, RESPONSE FROM SS_EVENT_CAPTURE WHERE COMPLETIONSTATUS = 0";

                    var inputStream = connection.QueryFirst<InputStream>(sqlstatement);
                    return inputStream;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //FileUtility.WriteToFile(Environment.CurrentDirectory + FileUtility.GetItFromAppConfig("NextStreamPositionFilePath"), callLog.PayLoad.NextStreamPosition);
        public static void InsertAccessTokenEventInToDatabase(List<AdditionalDetails> eventDetails, string dbConnectionString)
        {
            try
            {
                using (var connection = new SqlConnection(dbConnectionString))
                {
                    connection.Open();
                    var sqlstatement = @"Insert into  " + AccessTokenTable + " (ACCESSIBLEBY, ACCESSLEVEL, ACCESSSCOPES, ACTION, APPCLIENTID, APPNAME, ATTACHMENTNAME, CELLLINKSOURCESHEETID, DASHBOARDNAME, DECLINEREASON, DESTINATIONSHEETID, EMAILADDRESS, EVENTID, EventTimeStamp , FOLDERNAME, FORMATTYPE, FORMNAME, GROUPID, GROUPNAME, INCLUDEATTACHMENTS, INCLUDEDISCUSSIONS, MEMBERUSERID, MULTIFILEDOWNLOADNAME, NEWACCESSLEVEL, NEWCONTACTUSERID, NEWNAME, NEWOWNERUSERID, NEWPARENTCONTAINERID, NEWUSERID, OBJECTID, OBJECTTYPE , OLDACCESSLEVEL, OLDCONTACTUSERID, OLDNAME, OLDOWNERUSERID, OLDUSERID, PARENTCONTAINERID, PUBLISHFORMAT, PUBLISHTYPE, RECIPIENTEMAIL, RECIPIENTGROUPID, REPORTNAME, REQUESTUSERID, [ROWCOUNT], ROWSCOPIED, ROWSMOVED, SENDCOMPLETIONEMAIL, SHEETID, SHEETNAME, SHEETROWID, SOURCE, SOURCEFOLDERID, SOURCEGLOBALTEMPLATEID, SOURCEOBJECTID, SOURCESHEETID, SOURCETEMPLATEID, SOURCETYPE, TOKENDISPLAYVALUE, TOKENEXPIRATIONTIMESTAMP, TOKENNAME, TOKENUSERID, USERID, USERTYPES, WORKSPACEID) VALUES (@ACCESSIBLEBY, @ACCESSLEVEL, @ACCESSSCOPES, @ACTION, @APPCLIENTID, @APPNAME, @ATTACHMENTNAME, @CELLLINKSOURCESHEETID, @DASHBOARDNAME, @DECLINEREASON, @DESTINATIONSHEETID, @EMAILADDRESS, @EVENTID, @EventTimeStamp , @FOLDERNAME, @FORMATTYPE, @FORMNAME, @GROUPID, @GROUPNAME, @INCLUDEATTACHMENTS, @INCLUDEDISCUSSIONS, @MEMBERUSERID, @MULTIFILEDOWNLOADNAME, @NEWACCESSLEVEL, @NEWCONTACTUSERID, @NEWNAME, @NEWOWNERUSERID, @NEWPARENTCONTAINERID, @NEWUSERID, @OBJECTID, @OBJECTTYPE , @OLDACCESSLEVEL, @OLDCONTACTUSERID, @OLDNAME, @OLDOWNERUSERID, @OLDUSERID, @PARENTCONTAINERID, @PUBLISHFORMAT, @PUBLISHTYPE, @RECIPIENTEMAIL, @RECIPIENTGROUPID, @REPORTNAME, @REQUESTUSERID, @ROWCOUNT, @ROWSCOPIED, @ROWSMOVED, @SENDCOMPLETIONEMAIL, @SHEETID, @SHEETNAME, @SHEETROWID, @SOURCE, @SOURCEFOLDERID, @SOURCEGLOBALTEMPLATEID, @SOURCEOBJECTID, @SOURCESHEETID, @SOURCETEMPLATEID, @SOURCETYPE, @TOKENDISPLAYVALUE, @TOKENEXPIRATIONTIMESTAMP, @TOKENNAME, @TOKENUSERID, @USERID, @USERTYPES, @WORKSPACEID)";
                    connection.Execute(sqlstatement, eventDetails);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void BulkInsertEventInToDatabse(SuperEventDetails superEventDetails, List<KeyValuePair<string, string>> tablemapping, string dbConnString)
        {
            try
            {
                using (var tran = new TransactionScope())
                {
                    using (var conn = new SqlConnection(dbConnString))
                    {
                        conn.Open();

                        if (superEventDetails.EventDetailHeaders.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "EventDetailHeader").FirstOrDefault().Value, superEventDetails.EventDetailHeaders);

                        if (superEventDetails.AccessTokenDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "AccessToken").FirstOrDefault().Value, superEventDetails.AccessTokenDetails);

                        if (superEventDetails.AccountDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "Account").FirstOrDefault().Value, superEventDetails.AccountDetails);

                        if (superEventDetails.SheetDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "Sheet").FirstOrDefault().Value, superEventDetails.SheetDetails);

                        if (superEventDetails.ReportDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "Report").FirstOrDefault().Value, superEventDetails.ReportDetails);

                        if (superEventDetails.GroupDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "Group").FirstOrDefault().Value, superEventDetails.GroupDetails);

                        if (superEventDetails.FormDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "Form").FirstOrDefault().Value, superEventDetails.FormDetails);

                        if (superEventDetails.FolderDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "Folder").FirstOrDefault().Value, superEventDetails.FolderDetails);

                        if (superEventDetails.UserDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "User").FirstOrDefault().Value, superEventDetails.UserDetails);

                        if (superEventDetails.UpdateRequestDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "UpdateRequest").FirstOrDefault().Value, superEventDetails.UpdateRequestDetails);

                        if (superEventDetails.WorkSpaceDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "Workspace").FirstOrDefault().Value, superEventDetails.WorkSpaceDetails);

                        if (superEventDetails.AttachmentDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "Attachment").FirstOrDefault().Value, superEventDetails.AttachmentDetails);

                        if (superEventDetails.DashboardDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "Dashboard").FirstOrDefault().Value, superEventDetails.DashboardDetails);

                        if (superEventDetails.DiscussionDetails.Count != 0)
                            BulkInsert(conn, tablemapping.Where(m => m.Key == "Discussion").FirstOrDefault().Value, superEventDetails.DiscussionDetails);

                        tran.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static void BulkInsert<T>(SqlConnection connection, string tableName, IList<T> list)
        {

            using (var bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.BatchSize = list.Count;
                bulkCopy.DestinationTableName = tableName;
                bulkCopy.BulkCopyTimeout = 6000;

                var table = new DataTable();
                var props = TypeDescriptor.GetProperties(typeof(T))
                                            .Cast<PropertyDescriptor>()
                                            .Where(propertyInfo =>
                                                        propertyInfo.PropertyType.Namespace.Equals("System") ||
                                                        propertyInfo.PropertyType.Namespace.Equals("Microsoft.SqlServer.Types")
                                                        )
                                            .ToArray();

                foreach (var propertyInfo in props)
                {
                    bulkCopy.ColumnMappings.Add(propertyInfo.Name.ToUpper(), propertyInfo.Name.ToUpper());
                    table.Columns.Add(propertyInfo.Name.ToUpper(), Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
                }

                var values = new object[props.Length];
                foreach (var item in list)
                {
                    for (var i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }

                    table.Rows.Add(values);
                }
                bulkCopy.WriteToServer(table);
            }
        }

        public static string GetConfigurationFromDB(string KeyName)
        {            
            try 
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ToString()))
                {
                    //log.Info("Open SQL Connection");

                    connection.Open();

                    var sqlstatement = @"SELECT KeyValue FROM SS_CONFIGURATION WHERE [KEYNAME] = '" + KeyName + "'";

                    var keyValue = connection.QueryFirst<string>(sqlstatement);

                    return keyValue;
                }
            }
            catch(Exception ex)
            { throw ex; }
            
        }


        public static void UpdateNextPositionVal(string updateNextStreamPosition)
        {

            using (SqlConnection sqlcnn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ToString()))
            {
                try
                {
                    sqlcnn.Open();
                    string sqlquery = "Update SS_CONFIGURATION Set KEYVALUE='" + updateNextStreamPosition + "' WHERE KEYNAME ='NextStreamPosition' ";
                    sqlcnn.Execute(sqlquery);                                    
                    sqlcnn.Close();
                }

                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }


        }
    }
}
