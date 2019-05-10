
extends KinematicBody2D

# Declare member variables here. Examples:
# var a = 2
# var b = "text"
var linear_velocity = Vector2()
var SPEED = 100


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass

func _physics_process(delta):

	linear_velocity = move_and_slide(linear_velocity,Vector2(0,0))
	var target_speed = Vector2()
	if(Input.is_action_pressed("ui_up")):
		target_speed.y += 1
	if(Input.is_action_pressed("ui_down")):
		target_speed.y -= 1
	if(Input.is_action_pressed("ui_right")):
		target_speed.y += 1
	if(Input.is_action_pressed("ui_left")):
		target_speed.y -= 1
	
	target_speed *= SPEED
	linear_velocity.x = lerp(linear_velocity.x,target_speed.x,0.1)
	linear_velocity.y = lerp(linear_velocity.y,target_speed.y,0.1)



