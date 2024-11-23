
alphabet_dict = {"1":"A","2":"B","3":"C","4":"D","5":"E","6":"F","7":"G","8":"H","9":"I","10":"J","11":"K","12":"L","13":"M","14":"N","15":"O","16":"P","17":"Q","18":"R","19":"S","20":"T","21":"U","22":"V","23":"W","24":"X","25":"Y","0":"Z"}


def rotationalCipher(input_str, rotation_factor):
  orig_list = list(input_str)
  final_list = []
  for item in orig_list:
    if is_alphanumeric(item):
      final_list.append(get_cipher_value(item,rotation_factor))
    else:
      final_list.append(item)
  return ''.join(final_list)
  
  
def is_alphanumeric(text):
  return text.isalnum()

def get_cipher_value(input_char, rotation_factor):
  if input_char.isupper():
    return alphabet_dict[str((int(list(alphabet_dict.keys())[list(alphabet_dict.values()).index(input_char)])+rotation_factor)%26)]
  elif input_char.islower():
    return alphabet_dict[str((int(list(alphabet_dict.keys())[list(alphabet_dict.values()).index(input_char.upper())])+rotation_factor)%26)].lower()
  else:
    return str((int(input_char)+rotation_factor)%10)


if __name__ == "__main__":
  input = "2231Hy0*"
  rotation_factor = 4
  output = rotationalCipher(input, rotation_factor)
  print(output)
