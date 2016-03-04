import sys
import os

def file_check(file_path):
    if (not os.path.isfile(file_path) or not os.access(file_path, os.R_OK)):
        raise FileExistsError('Path is either a dir or cannot be accessed for reading')
def find_last_step_coordinates(file_path):
    x_coord = 0
    y_coord = 0
    has_changed = False
    with open(file_path, encoding='utf-8') as f:
        for line in f:
            line=line.strip()
            if line:
                splitted = line.split()
                if(splitted[0]=="left"):
                    x_coord -= float(splitted[1])
                    has_changed=True
                elif(splitted[0]=='right'):
                    x_coord += float(splitted[1])
                    has_changed=True
                elif(splitted[0]=='up'):
                    y_coord += float(splitted[1])
                    has_changed=True
                elif(splitted[0]=='down'):
                    y_coord -= float(splitted[1])
                    has_changed=True
    if(not has_changed):
        raise Exception
    return x_coord,y_coord

def main():
    try:

        file_path = input()

        file_check(file_path)

        x,y = find_last_step_coordinates(file_path)

        print('X {:.3f}'.format(x))
        print('Y {:.3f}'.format(y))
    except(Exception):
        print('INVALID INPUT')

if __name__ == '__main__':
    sys.exit(main())