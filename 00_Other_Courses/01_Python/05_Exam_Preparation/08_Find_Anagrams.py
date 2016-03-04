import sys

def build_dict(path):
    # Load in word file and sort each line.
    alpha = {}
    f = open(path, "r")
    for line in f.readlines():
        line = line.strip()
        key = sorted_line(line)

        # Add each line to a dictionary based on its sorted key.
        if key in alpha:
            v = alpha.get(key) + "," + line
            alpha[key] = v
        else:
            alpha[key] = line
    return alpha

def sorted_line(line):
    # Sort the chars in this line and return a string.
    chars = [c for c in line]
    chars.sort()
    return "".join(chars)

def anagram(alpha, line):
    # Return a list of anagrams from the dictionary.
    # ... Use a sorted string as the key.
    key = sorted_line(line)
    values = alpha.get(key, "NONE")
    return values.split(",")



def main():
    try:
        file_path = input()
        word = input()

        alpha = build_dict(file_path)
        results = anagram(alpha, word)
        if word in results:
            results.remove(word)
        results.sort()
        for each_word in results:
            print(each_word)

    except(Exception):
        print('INVALID INPUT')
if __name__ == '__main__':
    sys.exit(main())