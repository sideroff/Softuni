import sys
import os
from decimal import Decimal


def file_check(file_path):
    if (not os.path.isfile(file_path) or not os.access(file_path, os.R_OK)):
        raise FileNotFoundError('Path is either a dir or cannot be accessed for reading')

def exchange_rates_to_dict(file_path):
    money_dict = {}
    with open(file_path, encoding='utf-8') as f:
        for line in f:
            line = line.strip()
            if(line):
                country = line.split()[0]
                amount = line.split()[1]
                money_dict[country] = Decimal(amount)
    return money_dict

def amount_file_to_dict(file_path):
    ordered_entries = []
    with open(file_path, encoding='utf-8') as f:
        for line in f:
            line = line.strip()
            if(line):
                amount = line.split()[0]
                country = line.split()[1]
                ordered_entries.append((country, Decimal(amount)))
    return ordered_entries

def main():
    exchange_rate_file = input().strip(' ')
    amounts_file = input().strip(' ')

    if exchange_rate_file and amounts_file:
        try:
            file_check(exchange_rate_file)
            file_check(amounts_file)

            money_dict = exchange_rates_to_dict(exchange_rate_file)
            ordered_entries = amount_file_to_dict(amounts_file)

            for tuple in ordered_entries:
                country = tuple[0]
                amount = tuple[1]
                if country in money_dict.keys():
                    print("{:.2f}".format(amount / money_dict[country]))

        except(FileNotFoundError):
            print('INVALID INPUT')


    else:
        print('INVALID INPUT')


if __name__ == '__main__':
    sys.exit(main())