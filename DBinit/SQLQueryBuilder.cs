namespace DBinit
{
	public class SQLQueryBuilder
	{
		public static string CreateTable(string tableName, string columns) 
			=> $"CREATE TABLE IF NOT EXISTS {tableName} (\n{columns});";
		public static string InsertIntoTable(string tableName, string columns, string dynamicParameters) 
			=> $"INSERT INTO {tableName} ({columns}) values ({dynamicParameters});";

		public static string Select(string tableName, string columns, string? whereStatement = null, string? joinStatement = null) 
		{
			string query = $"SELECT {columns} FROM {tableName}";
			if(joinStatement != null)
			{
				query += " " + joinStatement;
			}
			if(whereStatement != null)
			{
				query += " " + whereStatement;
			}
			return query + ';';
		}
	}
}
