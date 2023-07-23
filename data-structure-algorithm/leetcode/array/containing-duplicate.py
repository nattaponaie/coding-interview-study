class Solution(object):
    def containsDuplicate(self, nums):
        """
        :type nums: List[int]
        :rtype: bool
        """

        hashed = set()

        for n in nums:
            if n in hashed:
                return True
            hashed.add(n)

        return False
        