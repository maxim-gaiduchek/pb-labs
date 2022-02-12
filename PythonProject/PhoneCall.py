from datetime import datetime


class PhoneCall:

    def __init__(self, phone_number, start, end):
        self.phone_number = phone_number
        self.start = start
        self.end = end

    def get_start_as_date(self) -> datetime:
        return datetime.strptime(self.start, "%H:%M")
