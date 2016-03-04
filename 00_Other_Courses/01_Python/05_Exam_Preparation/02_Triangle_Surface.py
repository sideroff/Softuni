import sys
import math


def main():

    try:
        input_side_a = float(input().strip(' '))
        input_side_b = float(input().strip(' '))
        input_side_c = float(input().strip(' '))
        if( is_triangle(input_side_a,input_side_b,input_side_c)):
            S = triangle_surface(input_side_a,input_side_b,input_side_c)
            print("{:.2f}".format(S))
        else:
            print('INVALID INPUT')
    except(ValueError):
        print('INVALID INPUT')

def is_triangle(x,y,z):
    if(z>(x+y)):
        return False
    elif(y>(x+z)):
        return False
    elif(x>(z+y)):
        return False
    else:
        return True

def triangle_surface(a,b,c):
    p = (a + b + c) / 2
    S = math.sqrt(p * (p - a) * (p - b) * (p - c))
    return S

if __name__ == '__main__':
    sys.exit(main())