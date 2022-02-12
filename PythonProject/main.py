from datetime import datetime
import pickle

from PhoneCall import PhoneCall


def main():
    input_path = "input.txt"
    day_output_path = "dayOutput.txt"
    night_output_path = "nightOutput.txt"

    calls = get_input_phone_calls(input_path)
    day_calls = get_day_calls(calls)
    night_calls = get_night_calls(calls)

    output_phone_calls(calls, "Input phone calls:")
    output_phone_calls(day_calls, "Input day phone calls:")
    output_phone_calls(night_calls, "Input night phone calls:")

    write_calls_to_file(day_calls, day_output_path)
    write_calls_to_file(night_calls, night_output_path)

    file_day_calls = get_calls_from_file(day_output_path)
    file_night_calls = get_calls_from_file(night_output_path)

    output_phone_calls(file_day_calls, "File day phone calls:")
    output_phone_calls(file_night_calls, "File night phone calls:")


def get_input_phone_calls(path: str) -> list:
    calls = []

    with open(path, "r") as file:
        for line in file:
            data = line.strip().split()

            calls.append(PhoneCall(data[0], data[1], data[2]))

    return calls


def output_phone_calls(calls: list, prompt: str) -> None:
    print(prompt)

    for call in calls:
        print("PhoneCall:", call.phone_number, call.start, call.end)

    print()


def get_day_calls(calls: list) -> list:
    result = []
    start_time = datetime.strptime("06:00", "%H:%M")
    end_time = datetime.strptime("20:00", "%H:%M")

    for call in calls:
        if start_time <= call.get_start_as_date() < end_time:
            result.append(call)

    return result


def get_night_calls(calls: list) -> list:
    result = []
    start_time = datetime.strptime("20:00", "%H:%M")
    end_time = datetime.strptime("06:00", "%H:%M")

    for call in calls:
        if start_time <= call.get_start_as_date() or call.get_start_as_date() < end_time:
            result.append(call)

    return result


def write_calls_to_file(calls: list, path: str) -> None:
    with open(path, "ab") as file:
        for call in calls:
            pickle.dump(call, file)


def get_calls_from_file(path: str) -> list:
    calls = []

    with open(path, "rb") as file:
        while True:
            try:
                calls.append(pickle.load(file))
            except EOFError:
                break

    return calls


if __name__ == '__main__':
    main()
