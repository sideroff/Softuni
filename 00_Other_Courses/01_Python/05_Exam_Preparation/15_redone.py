import sys
import os

def file_check(file_path):
    if (not os.path.isfile(file_path) or not os.access(file_path, os.R_OK)):
        raise FileExistsError('Path is either a dir or cannot be accessed for reading')

def file_info_to_dicts(file_path):
    dict_of_cities = dict()
    dict_of_item_ids = dict()
    with open(file_path, encoding='utf-8') as f:
        for line in f:
            line = line.strip()
            if line:
                splitted = line.split(',')
                item_id = splitted[0]
                city_name = splitted[2]

                if item_id not in dict_of_item_ids:
                    dict_of_item_ids[item_id] = list()
                if(city_name not in dict_of_cities):
                    dict_of_cities[city_name] = list()
                dict_of_item_ids[item_id].append(city_name)
                dict_of_cities[city_name].append(item_id)

    return dict_of_cities, dict_of_item_ids

def main():
    try:
        file_path = input()
        file_check(file_path)

        dict_of_cities,\
        dict_of_item_ids = file_info_to_dicts(file_path)

        sorted_cities = sorted(dict_of_cities.keys())

        output_list = list()
        for city in sorted_cities:
            output = city.strip('"')
            has_changed = False
            sorted_items_ids = sorted(dict_of_cities[city])
            for each_id in sorted_items_ids:
                correct_len = len(dict_of_item_ids[each_id])==1
                correct_city = dict_of_item_ids[each_id][0] == city
                if( correct_len & correct_city):
                    output+=','+each_id.strip('"')
                    has_changed = True
            if(has_changed):
                output_list.append(output)
        if(len(output_list) >0):
            for line in output_list:
                print(line)
        else:
            print('NO UNIQUE SALES')
    except(Exception):
        print('INVALID INPUT')

if __name__ == '__main__':
    sys.exit(main())