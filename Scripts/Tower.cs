using Godot;
using System;

public partial class Tower : Area3D
{

	private PackedScene _bullet = GD.Load<PackedScene>("res://Scenes/Bullet.tscn");

	private Timer _myTimer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_myTimer = GetNode<Timer>("Timer");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
