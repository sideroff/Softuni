import sys
import os
import math

from decimal import Decimal
def file_check(file_path):
    if (not os.path.isfile(file_path) or not os.access(file_path, os.R_OK)):
        raise FileExistsError('Path is either a dir or cannot be accessed for reading')

def containers_from_file_as_dict(file_path):
    containers_list_of_tuples = list()
    with open(file_path, encoding='utf-8') as f:
        for line in f:
            line=line.strip()
            if line:
                splitted = line.split(',')
                #π*r^2*h
                r = float(splitted[1])
                h = float(splitted[2])
                if r<=0 or h<=0:
                    raise Exception

                volume = math.pi * math.pow(r,2) * h
                containers_list_of_tuples.append((splitted[0],volume))

    return containers_list_of_tuples
#TRY EMPTY FILE
def main():
    try:
        litres_rakiya = float(input())
        if litres_rakiya<0:
            raise Exception
        file_path = input()

        file_check(file_path)

        containers_list_of_tuples = containers_from_file_as_dict(file_path)

        name_of_container = ''
        minimal_difference = Decimal('Infinity')

        for item in containers_list_of_tuples:
            difference_in_litres = (item[1]/1000)-litres_rakiya
            if(difference_in_litres>=0  and difference_in_litres<minimal_difference):
                minimal_difference = difference_in_litres
                name_of_container = item[0]

        if(name_of_container):
            print(name_of_container)
        else:
            print('NO SUITABLE CONTAINER')

    except(Exception):
        print('INVALID INPUT')

if __name__ == '__main__':
    sys.exit(main())