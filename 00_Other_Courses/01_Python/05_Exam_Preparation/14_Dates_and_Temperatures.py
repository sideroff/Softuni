import sys
import os
import iso8601
from datetime import date
from datetime import datetime, timezone


def file_check(file_path):
    if (not os.path.isfile(file_path) or not os.access(file_path, os.R_OK)):
        raise FileExistsError('Path is either a dir or cannot be accessed for reading')

def dates_from_file_to_dict_of_tuples(file_path):
    dict_of_tuples = {}
    cities = set()
    has_data = False
    with open(file_path, encoding='utf-8') as f:
        for line in f:
            line=line.strip()
            if(line):
                splitted = line.split(',')
                date = iso8601.parse_date(splitted[0].strip())
                city = splitted[1]
                has_data = True
                if(date not in dict_of_tuples):
                    dict_of_tuples[date] = set()
                dict_of_tuples[date].add(city)
                cities.add(city)
    if(not has_data):
        raise Exception
    return dict_of_tuples,\
           cities,

#STRIP OF QUOTATIONS
def main():
    try:
        file_path = input()
        file_check(file_path)

        dict_of_tuples, \
        list_of_cities = dates_from_file_to_dict_of_tuples(file_path)

        output = list()
        sorted_dates = sorted(dict_of_tuples.keys(), reverse=False)
        for date in sorted_dates:
            differences = dict_of_tuples[date]^list_of_cities
            if differences:
                stringche = str(date.year) +'-'+'{:02d}'.format(date.month) + '-' + '{:02d}'.format(date.day)
                sorted_differences = sorted(differences)
                for each in sorted_differences:
                    stringche+=',' + each
                output.append(stringche)

        if output:
            for each_line in output:
                print(each_line)
        else:
            print('ALL DATA AVAILABLE')
    except(Exception):
        print('INVALID INPUT')

if __name__ == '__main__':
    sys.exit(main())