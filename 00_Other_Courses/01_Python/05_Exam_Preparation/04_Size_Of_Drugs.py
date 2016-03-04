import sys
import os

class ThreeDeeObject():
    def __init__(self,name, width, height, depth):
        sorted_sides = [width,height,depth]
        sorted_sides.sort()
        self.name = name
        self.width = sorted_sides[0]
        self.height = sorted_sides[1]
        self.depth = sorted_sides[2]

    def canFitInto(self, other):
        if(self.width<other.width
           and self.height < other.height
           and self.depth < other.depth):
            return True
        return False

def file_check(file_path):
    if (not os.path.isfile(file_path) or not os.access(file_path, os.R_OK)):
        raise FileNotFoundError('Path is either a dir or cannot be accessed for reading')


def file_to_list_of_tuple_three_dee_objects(file_path):
    entries = []
    with open(file_path, encoding='utf-8') as f:
        for line in f:
            line = line.strip()
            if(line):
                splitted = line.split(',')
                name = splitted[0]
                width = float(splitted[1])
                height = float(splitted[2])
                depth = float(splitted[3])
                entries.append(ThreeDeeObject(name,width,height,depth))
    return entries

def main():
    width = float(input())
    height = float(input())
    depth = float(input())
    packages_file = input().strip(' ')

    box = ThreeDeeObject('box',width,height,depth)

    if packages_file:
        try:
            file_check(packages_file)

            three_dee_objects = file_to_list_of_tuple_three_dee_objects(packages_file)

            for tdo in three_dee_objects:
                if(tdo.canFitInto(box)):
                    print(tdo.name)

        except(FileNotFoundError):
            print('INVALID INPUT')
    else:
        print('INVALID INPUT')

if __name__ == '__main__':
    sys.exit(main())