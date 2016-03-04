import requests
import sys
from decimal import Decimal

dictionary_i_need = {'rates': {'PLN': 5.7643, 'ILS': 5.7171, 'TRY': 4.2431, 'PHP': 69.673, 'NOK': 12.452, 'RON': 5.8864, 'SEK': 12.277, 'AUD': 2.0296, 'IDR': 19936.0, 'NZD': 2.1774, 'HUF': 405.37, 'INR': 99.04, 'MYR': 6.0219, 'EUR': 1.3056, 'CAD': 2.0061, 'BRL': 5.6774, 'CZK': 35.278, 'USD': 1.463, 'KRW': 1745.2, 'MXN': 26.516, 'SGD': 2.0524, 'HRK': 10.002, 'THB': 52.16, 'ZAR': 23.196, 'HKD': 11.395, 'RUB': 112.38, 'JPY': 171.67, 'CHF': 1.4582, 'DKK': 9.7433, 'CNY': 9.6209, 'BGN': 2.5534}, 'date': '2016-02-04', 'base': 'GBP'}
EXCHANGE_RATES_URL_FORMAT = 'http://api.fixer.io/latest?base={}'
DEFAULT_TIMEOUT = 1

def parse_command_line_arguments():
    if len(sys.argv) < 3:
        raise ValueError('Invalid number of parameters supplied.')
    return sys.argv[1], sys.argv[2]


def main():
    currency_abriviation = input('Въведете валута: ')
    currency_ammount = Decimal(input('Въведете сума: '))

    #currency_abriviation,\
    #    currency_ammount_as_text = parse_command_line_arguments()

    #currency_ammount = Decimal(currency_ammount_as_text)

    print("Getting data...")
    resp = requests.get(EXCHANGE_RATES_URL_FORMAT.format(currency_abriviation), timeout=DEFAULT_TIMEOUT)
    dict_of_currencies = resp.json()
    print('Равностойност в BGN: {}'.format(float(currency_ammount)*float(dict_of_currencies['rates'].get('BGN'))))


if __name__ == '__main__':
    sys.exit(main())