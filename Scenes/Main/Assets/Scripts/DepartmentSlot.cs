using Godot;

public partial class DepartmentSlot : Panel
{
	[Export] private Label _departmentNameLabel;
	[Export] private Label _headcountLabel;

	public void SetDepartmentData(string departmentName, int headcount)
	{
		_departmentNameLabel.Text = departmentName;
		_headcountLabel.Text = $"Headcount: {headcount}";
	}
}
