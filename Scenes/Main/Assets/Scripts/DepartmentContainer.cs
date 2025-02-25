using Godot;
using System;

/* Summary
This class is attached to DepartmentContainer(GridContainer)

it shows department info dynamically 
*/
public partial class DepartmentContainer : GridContainer
{
	[Export] private GridContainer _departmentContainer;
	[Export] private PackedScene _departmentSlotScene;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (_departmentContainer == null || _departmentSlotScene == null)
		{
			GD.PrintErr("DepartmentContainer or DepartmentSlotScene is not assigned!");
			return;
		}

		PopulateDepartments();
		
	}

	private void PopulateDepartments()
	{
		foreach (Node child in _departmentContainer.GetChildren())
		{
			child.QueueFree();
		}

		var departments = AssetData.Departments;

		foreach (var department in departments)
		{
			var slot = _departmentSlotScene.Instantiate<DepartmentSlot>();
			slot.SetDepartmentData(department.Name, department.Employees.Count);
			_departmentContainer.AddChild(slot);
		}
	}
}
