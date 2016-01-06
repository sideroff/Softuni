import turtle


def printSquares():
    for i in range(8):
        if i % 2 == 0:
            t.begin_fill()
        t.forward(side)
        t.left(90)
        t.forward(side)
        t.left(90)
        t.forward(side)
        t.left(90)
        t.forward(side)
        t.left(90)
        t.end_fill()
        t.forward(side)

side = 20
t = turtle.Turtle()
t.speed('fastest')

for j in range(8):
    if j % 2 == 0:
        printSquares()
        t.left(90)
        t.forward(side * 2)
        t.left(90)
    else:
        printSquares()
        t.right(180)
t.exitonclick()