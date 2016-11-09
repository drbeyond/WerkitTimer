using SQLite;

public class Person
{
	[PrimaryKey, AutoIncrement]
	public int id { get; set; }

	public string Label { get; set; }

	public string Seconds { get; set; }

	public string Rounds { get; set; }


}
