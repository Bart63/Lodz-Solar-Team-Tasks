# %%
import flask
import numpy as np
from flask import jsonify, request
from datetime import datetime
from random import randint, choice
from random import random as randfloat
randbool = lambda: choice([True, False])
randstring = lambda *s: choice([s])
randlist = lambda size, mul: [(randfloat() * mul) for _ in range(size)]

app = flask.Flask(__name__)
app.config["DEBUG"] = True

# Create some test data for our catalog in the form of a list of dictionaries.
car = {
	'general': {
		'timestamp': datetime.now(), 	# current time
		'speed': 0, 						# speed in km/h
		'mileage': 0, 						# mileage in km
		'driveMode': 'eco' 					# or 'power' 
	},
	'battery': {
		'stateOfCharge': 0, 				# state of charge in %
		'temperature': 0, 					# temperature in celsius degrees
		'errors': {
			'overheat': False, 				# error about overheating
			'noSignal': False, 				# error about lack of signal from battery
			'other': False 					# undefined error
		}
	},
	'tires': {
		'pressure': [0, 0, 0, 0]			# tire pressures in kPa; frontleft, frontright, backleft, backright
	}
}

summary = {
	'timeMinutes': 0, 						# how many minutes is summary taken from
	'powerUsage': [0], 						# total power usage for every minute of timeMinutes; in kW
	'powerUsageAvg': [0], 					# average power usage for every minute of timeMinutes; in kW/km
	'coveredDistance': [0] 					# covered distance for every minute of timeMinutes; in km
}

@app.route('/api/car', methods=['GET'])
def api_recent():
	car['general']['timestamp'] = datetime.now()
	car['general']['driveMode'] = randstring('power', 'eco')
	car['battery']['stateOfCharge'] = randfloat() * 100
	car['battery']['errors']['other'] = randbool()
	car['tires']['pressure'] = randlist(4, 100)
	# TWEAK YOUR OWN TEST VALUES HERE
	car['general']['speed'] = randint(0, 120)

	# TWEAK YOUR OWN TEST VALUES HERE

	return jsonify(car)

@app.route('/api/summary', methods=['GET'])
def api_summary():
	if 'time' in request.args:
		time = int(request.args['time'])
	else:
		return "Error: No time field provided. Please specify time in minutes."

	# TWEAK YOUR OWN TEST VALUES HERE
	summary['powerUsage'] = randlist(time, 20)
	summary['coveredDistance'] = randlist(time, 20)
	summary['powerUsageAvg'] = list(np.divide(summary['powerUsage'], summary['coveredDistance']))
	# TWEAK YOUR OWN TEST VALUES HERE

	summary['timeMinutes'] = time
	return jsonify(summary)

app.run()
# %%
