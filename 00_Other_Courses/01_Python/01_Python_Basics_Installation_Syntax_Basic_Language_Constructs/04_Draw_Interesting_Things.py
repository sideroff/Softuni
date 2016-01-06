import turtle

i = 10

t = turtle.Turtle()
t.speed('fastest')

while True:
    t.left(i % 31*57)
    t.forward(10)
    i+=1