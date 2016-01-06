import turtle

t = turtle.Turtle()
t.speed('slowest')
t.color('red')

for a in range(0,4):
    t.forward(50)
    t.right(90)

wait = input("Press Enter to continue...")