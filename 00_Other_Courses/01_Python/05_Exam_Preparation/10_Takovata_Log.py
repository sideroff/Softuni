import sys
import re

def log_file_to_list(file_path):
    list_of_logs = list()
    with open(file_path, encoding='utf-8') as f:
         for line in f:
             if(line.strip()):
                 list_of_logs.append(line)
    return list_of_logs

def list_of_logs_to_dict_of_response_times(list_of_logs):
    dictionary_of_names = dict()
    for log in list_of_logs:
        m = re.match('resp_t="(.*?)"', log)
        if m:
            if m.group(1) in

def main():
    try:
        file_path = input()
        list_of_logs = log_file_to_list(file_path)


    except(Exception):
        print('INVALID INPUT')
if __name__ == '__main__':
    sys.exit(main())