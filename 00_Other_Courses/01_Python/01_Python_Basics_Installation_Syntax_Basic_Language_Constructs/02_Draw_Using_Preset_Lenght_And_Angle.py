import turtle

t = turtle.Turtle()
t.speed('slowest')
t.color('red')

angle = int(input('Choose angle of rotation'))
sides = 360//angle
lenght = int(input('Choose lenght'))

for a in range(0,sides):
    t.forward(lenght)
    t.right(angle)