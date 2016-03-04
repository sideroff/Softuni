import sys

def fridge_info_to_list_of_tuples(file_path):
    list_of_tuples = list()
    with open(file_path, encoding='utf-8') as f:
        for line in f:
            if(line.strip()):
                splitted = line.split(',')
                list_of_tuples.append((splitted[0],float(splitted[1])))
    return list_of_tuples

def find_openings_of_fridge(list_of_tuples):
    default_temp = list_of_tuples[1][1]
    for each_entry in list_of_tuples:
        if each_entry[1]-default_temp>4:
            print(each_entry[0])
        default_temp = each_entry[1]

def main():
    try:
        file_path = input()
        list_of_fridge_times = fridge_info_to_list_of_tuples(file_path)
        find_openings_of_fridge(list_of_fridge_times)

    except(Exception):
        print('INVALID INPUT')
if __name__ == '__main__':
    sys.exit(main())