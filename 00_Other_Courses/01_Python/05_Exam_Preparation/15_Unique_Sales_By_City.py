import sys
import os
import iso8601

def file_check(file_path):
    if (not os.path.isfile(file_path) or not os.access(file_path, os.R_OK)):
        raise FileExistsError('Path is either a dir or cannot be accessed for reading')

def file_to_dict_of_cities(file_path):
    dict_of_items = dict()
    with open(file_path, encoding='utf-8') as f:
        for line in f:
            if not line.isspace():
                line = line.strip().replace('"', "")
                splitted = line.split(',')
                item_id = splitted[0]
                country = splitted[1]
                city = splitted[2]
                # date = iso8601.parse_date(splitted[3])
                price = float(splitted[4].strip('"'))
                if(item_id not in dict_of_items):
                    dict_of_items[city] = list()
                if city not in dict_of_items[item_id]:
                    dict_of_items[item_id].append(city)

    return dict_of_items
def main():
    try:
        file_path = input()
        file_check(file_path)

        items = file_to_dict_of_cities(file_path)
        cities = {}
        has_any = False
        for id in items.keys():
            if len(items[id]) == 1:
                has_any = True
                city = items[id][0]
                if city not in cities:
                    cities[city] = []
                    cities[city].append(id)
                else:
                    cities[city].append(id)
        if(has_any):
            for city in cities:
                cities[city].sort()
                print(city + "," + ",".join(cities[city]))
        else:
            print('NO UNIQUE SALES')
    except(Exception):
        print('INVALID INPUT')

if __name__ == '__main__':
    sys.exit(main())