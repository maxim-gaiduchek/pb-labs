import pickle
from datetime import datetime

from PhoneCall import PhoneCall


def main():
    #  init constants
    input_path = "input.txt"
    day_output_path = "dayOutput.txt"
    night_output_path = "nightOutput.txt"

    #  init input entities, serialize and deserialize them, filtering day and night calls
    init_entities(input_path)

    calls = get_calls_from_file(input_path)
    day_calls = get_day_calls(calls)
    night_calls = get_night_calls(calls)

    output_phone_calls(calls, "Input phone calls:")
    output_phone_calls(day_calls, "Input day phone calls:")
    output_phone_calls(night_calls, "Input night phone calls:")

    #  serialize day and night calls
    write_calls_to_file(day_calls, day_output_path, "ab")
    write_calls_to_file(night_calls, night_output_path, "ab")

    #  deserialize all day and night calls
    file_day_calls = get_calls_from_file(day_output_path)
    file_night_calls = get_calls_from_file(night_output_path)

    output_phone_calls(file_day_calls, "File day phone calls:")
    output_phone_calls(file_night_calls, "File night phone calls:")


def init_entities(path: str):
    calls = [
        PhoneCall("+380999999999", "06:00", "19:59"),
        PhoneCall("+380228133700", "06:00", "20:00"),
        PhoneCall("+380952281337", "20:00", "06:00"),
        PhoneCall("+380555555555", "03:00", "07:37"),
        PhoneCall("+380555555555", "17:28", "21:28"),
        PhoneCall("+380333333337", "20:00", "05:59"),
        PhoneCall("+380222222222", "06:00", "06:02"),
        PhoneCall("+380111111111", "20:00", "02:58")
    ]

    write_calls_to_file(calls, path, "wb")


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


def write_calls_to_file(calls: list, path: str, mode: str) -> None:
    with open(path, mode) as file:
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
