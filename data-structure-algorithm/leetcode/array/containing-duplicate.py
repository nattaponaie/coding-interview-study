class Solution(object):
    def containsDuplicate(self, nums):
        """
        :type nums: List[int]
        :rtype: bool
        """

        hashed = set()

        for n in nums:
            if n in hashed:
                return true
            hashed.add(n)

        return false
        