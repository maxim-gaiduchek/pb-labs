#include <string>
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

struct PhoneCall {
	string phoneNumber, start, end;
};

vector<PhoneCall> get_input_phone_calls(string path) {
	vector<PhoneCall> calls = vector<PhoneCall>();
	ifstream file(path);
	string line;

	while (!file.eof()) {
		PhoneCall call;

		file >> call.phoneNumber >> call.start >> call.end;
		calls.push_back(call);
	}

	file.close();

	return calls;
}

void output_phont_calls(vector<PhoneCall> calls, string prompt) {
	cout << prompt << endl;

	for (PhoneCall call : calls) {
		cout << "PhoneCall: " << call.phoneNumber << " " << call.start << " " << call.end << endl;
	}

	cout << endl;
}

vector<PhoneCall> get_calls_between(vector<PhoneCall> calls, int from, int to) {
	vector<PhoneCall> result = vector<PhoneCall>();

	for (PhoneCall call : calls) {
		int hour = atoi(new char[] {call.start[0], call.start[1]});

		if (from <= to ? from <= hour && hour < to : from <= hour || hour < to) {
			result.push_back(call);
		}
	}

	return result;
}

void write_calls_to_file(vector<PhoneCall> calls, string path) {
	ofstream file(path, ios::binary);

	for (PhoneCall call : calls) {
		file.write((char*) &call, sizeof(PhoneCall));
	}

	file.close();
}

vector<PhoneCall> read_calls_from_file(string path) {
	vector<PhoneCall> calls = vector<PhoneCall>();
	PhoneCall call;
	ifstream file(path, ios::binary);

	while (file.read((char*) &call, sizeof(PhoneCall))) {
		calls.push_back(call);
	}

	file.close();
	
	return calls;
}

int main() {
	const string inputPath = "input.txt";
	const string dayOutputPath = "dayOutput.txt";
	const string nightOutputPath = "nightOutput.txt";

	vector<PhoneCall> calls = get_input_phone_calls(inputPath);

	output_phont_calls(calls, "Input calls:");

	vector<PhoneCall> dayCalls = get_calls_between(calls, 6, 20);
	vector<PhoneCall> nightCalls = get_calls_between(calls, 20, 6);

	output_phont_calls(dayCalls, "Input day calls:");
	output_phont_calls(nightCalls, "Input night calls:");

	write_calls_to_file(dayCalls, dayOutputPath);
	write_calls_to_file(nightCalls, nightOutputPath);

	vector<PhoneCall> fileDayCalls = read_calls_from_file(dayOutputPath);
	vector<PhoneCall> fileNightCalls = read_calls_from_file(nightOutputPath);

	output_phont_calls(fileDayCalls, "File day calls:");
	output_phont_calls(fileNightCalls, "File night calls:");

	return 0;
}