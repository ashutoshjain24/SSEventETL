using System;

namespace SSEventsETL.Enumerations
{
    public class Enums
    {
        public enum ObjectType { Events, Users, Sheets, Sights, Reports, WorkSpaces, Groups }
        public enum EventType { User, Sheet, Sight, Report, WorkSpace, Group, Account, AccessToken, Dashboard, Discussion, Folder, Form, UpdateRequest }

        public enum TableName { User, Sheet, Sight, Report, WorkSpace, Group, Account, AccessToken, Dashboard, Discussion, Folder, Form, UpdateRequest, Users, Sheets, Sights, Reports, WorkSpaces, Groups }

    }
}
