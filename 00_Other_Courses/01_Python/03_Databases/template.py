import csv
import os
import iso8601
import sys
from decimal import Decimal
from datetime import datetime, timezone
import sqlite3


class Item():
    def __init__(self, id, name, colours, group, sport_designed_for, category, sub_category, sex):
        self.id = id
        self.name = name
        self.colours = colours.split('/')
        self.group = group
        self.sport_designed_for = sport_designed_for
        self.category = category
        self.sub_category = sub_category
        self.sex = sex

    def __repr__(self):
        return "Item: " + str(self.__dict__)


class Sale():
    def __init__(self, item_id, country, city, sale_timestamp, price):
        self.item_id = item_id
        self.country = country
        self.city = city
        self.sale_timestamp = iso8601.parse_date(sale_timestamp)
        if self.sale_timestamp.tzinfo is None:
            raise ValueError("Naive datetimes not supported")
        else:
            self.sale_timestamp = self.sale_timestamp.astimezone(timezone.utc)
        self.price = Decimal(price)

    def __repr__(self):
        # какъв беше начина да се вземе името на класа автоматично
        return "Sale: " + str(self.__dict__)


def parse_command_line_arguments():
    if len(sys.argv) < 3:
        raise ValueError('Invalid number of parameters supplied.')
    return sys.argv[1], sys.argv[2]


def file_check(file_path):
    if (not os.path.isfile(file_path) or not os.access(file_path, os.R_OK)):
        raise FileExistsError('Path is either a dir or cannot be accessed for reading')


def read_csv(file_path):
    with open(file_path) as f:
        reader = csv.reader(f)
        info_list = list(reader)
        return info_list


def catalog_info_to_dict_of_items(catalog_info):
    item_dict = {}
    for line in catalog_info:
        new_item = Item(id=line[0],
                        name=line[1],
                        colours=line[2],
                        group=line[3],
                        sport_designed_for=line[4],
                        category=line[5],
                        sub_category=line[6],
                        sex=line[7])
        item_dict[line[0]] = new_item

    return item_dict


def sales_info_to_dict_of_sales(sales_info):
    sale_dict = {}
    # for later use in printing report by city
    for line in sales_info:
        sale = Sale(item_id=line[0], country=line[1], city=line[2], sale_timestamp=line[3], price=line[4])
        sale_dict[sale.item_id] = sale
    return sale_dict


def create_tables(connection):
    cursor = connection.cursor()
    cursor.execute("""
        create table if not exists sale (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            FOREIGN KEY(item_id) REFERENCES catalog(item_id),
            country varchar(3),
            city_name varchar(60),
            sale_timestamp TEXT,
            price NUMERIC
        );
    """)

    cursor.execute("""
        create table if not exists catalog (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            item_key varchar(200),
            category varchar(200)
        );
    """)

    cursor.execute("select * from sale")
    print(cursor.fetchall())
    cursor.execute("select * from catalog")
    print(cursor.fetchall())



def import_sales_to_tables(sales_dict,connection):
    cursor = connection.cursor()
    for k,v in sales_dict.items():
        cursor.execute("insert INTO sale (item_key, country, city_name, sale_timestamp,price) VALUES (?,?,?,?,?)",[v.item_id, v.country, v.city, str(v.sale_timestamp),str(v.price)])

def import_catalog_to_tables(catalog_dict,connection):
    cursor = connection.cursor()
    for k,v in catalog_dict.items():
        cursor.execute("""insert into catalog (item_key, category) VALUES (?,?)""",[v.id,v.category])

def main():
    try:
        # catalog_file_path,\
        # sales_file_path = parse_command_line_arguments()
        catalog_file_path = 'catalog-example.csv'
        sales_file_path = 'sales-example.csv'

        file_check(catalog_file_path)
        file_check(sales_file_path)

        catalog_info = read_csv(catalog_file_path)
        sales_info = read_csv(sales_file_path)

        catalog_items = catalog_info_to_dict_of_items(catalog_info)
        sales_dict = sales_info_to_dict_of_sales(sales_info)

        database_file_path = "sales-example.db"
        file_check(database_file_path)

        """--------------------------------------------------------"""
        with sqlite3.connect(database_file_path, isolation_level=None) as connection:
            create_tables(connection)
            print("tables created")
            import_catalog_to_tables(catalog_items,connection)
            import_sales_to_tables(sales_dict,connection)
            print("sales and catalog items added")

            print(connection.cursor().execute("select * from catalog").fetchall())
            print(connection.cursor().execute("select * from sale").fetchall())

            pass



    except ValueError as e:
        print('imate greshka be')


if __name__ == '__main__':
    sys.exit(main())
