import sys
import os

def file_check(file_path):
    if (not os.path.isfile(file_path) or not os.access(file_path, os.R_OK)):
        raise FileNotFoundError('Path is either a dir or cannot be accessed for reading')

def calculate_time_from_start_to_end(file_path):
    time = float(0)
    with open(file_path, encoding='utf-8') as f:
        for line in f:
            line = line.strip()
            if(line):
                splitted = line.split(',')

                start = int(splitted[0])
                end = int(splitted[1])
                speed = float(splitted[2])

                lenght = end -start +1

                time += lenght/speed
    return time

def main():
    speed_regulations_file = input().strip()
    if speed_regulations_file:
        try:
            file_check(speed_regulations_file)

            total_time = calculate_time_from_start_to_end(speed_regulations_file)

            print('{:.2f}'.format(total_time))

        except(FileNotFoundError):
            print('INVALID INPUT')
    else:
        print('INVALID INPUT')

if __name__ == '__main__':
    sys.exit(main())