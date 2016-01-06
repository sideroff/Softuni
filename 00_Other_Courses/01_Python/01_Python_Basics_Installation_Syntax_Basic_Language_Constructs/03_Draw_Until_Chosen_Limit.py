import turtle

t = turtle.Turtle()
t.speed('slowest')
t.color('red')

g = 360//int(input('choose number of sides'))
l = 120
i = int(input('number of iterations: '))

while i!=0:
    turtle.left(g)
    turtle.forward(l)
    i-=1