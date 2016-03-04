import sys
import os
from decimal import Decimal

def file_check(file_path):
    if (not os.path.isfile(file_path) or not os.access(file_path, os.R_OK)):
        raise FileNotFoundError('Path is either a dir or cannot be accessed for reading')

def find_minimal_price_for_item_by_city(city_name,file_path):
    city = ""
    minimal_price = Decimal('Infinity')
    with open(file_path, encoding='utf-8') as f:
        for line in f:
            if(line.split(',')[0].strip('"') == city_name):
                #shitty way but it works
                splitted = line.split(',')
                actual_price = Decimal(splitted[-1])
                if(minimal_price > actual_price):
                    minimal_price = actual_price
                    city = splitted[2]
    return city.strip('"')

def main():
    city_name = input().strip()
    sales_file = input().strip()


    if sales_file:
        try:
            file_check(sales_file)

            city = find_minimal_price_for_item_by_city(city_name,sales_file)

            print(city)
        except(FileNotFoundError):
            print('INVALID INPUT')
    else:
        print('INVALID INPUT')

if __name__ == '__main__':
    sys.exit(main())