import sqlite3

connection = sqlite3.connect('sales-example.db', isolation_level=None)
print('connected')

category_id = input("Въведете ид ").strip()
category_name = input("въведете категория ").strip()

cursor = connection.cursor()
cursor.execute(''
               'UPDATE sale'
               ' set country = ?'
               ' WHERE id =?',[category_name, category_id])
results = cursor.fetchall()
print(results)

cursor.execute('SELECT * FROM sale WHERE id=1')
results=cursor.fetchall()
print(results)