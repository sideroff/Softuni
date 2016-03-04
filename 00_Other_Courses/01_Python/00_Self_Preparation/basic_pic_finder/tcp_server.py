import os
import sys
import socket

def get_files():
    necessary_files =[]
    for root, dirs, files in os.walk("../../"):
        path = root.split('/')

        for file in files:
            if(file.__contains__('.jpg')):
                necessary_files.append(path+file)

def main():
    host = '127.0.0.1'
    port = 5000

    s = socket.socket()
    s.bind((host,port))

    s.listen(1)
    c, addr = s.accept()
    print('connection from: ' + str(addr))

    while True:
        data = c.recv(1024)
        if not data:
            break
        print('from connected user: ' + str(data))
        data = str(data).upper()
        print('sending: ' + str(data))
        c.send(bytes(data, 'UTF-8'))
    c.close()

if __name__ == '__main__':
    sys.exit(main())