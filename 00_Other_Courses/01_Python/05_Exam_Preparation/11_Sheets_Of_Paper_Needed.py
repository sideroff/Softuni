import sys
import math

def main():
    try:
        paper = float(input())
        height = float(input())
        width = float(input())
        lenght = float(input())

        surface_area = 2*lenght*width+2*lenght*height+2*width*height
        surface_area *= 1.098
        print(math.ceil(surface_area/paper))

    except(Exception):
        print('INVALID INPUT')

if __name__ == '__main__':
    sys.exit(main())